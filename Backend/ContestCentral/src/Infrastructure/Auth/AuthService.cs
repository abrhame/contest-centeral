using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Web;

using Application.DTOs;
using Application.Common.Models;
using Application.Interfaces;
using Domain.Entity;
using Infrastructure.Persistence;

namespace Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly ContestCentralDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IEmailService _emailService;
    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService( 
            IMapper mapper, 
            ContestCentralDbContext context, 
            ITokenService tokenService, 
            IPasswordService passwordService, 
            IEmailService emailService,    
            ILogger logger,
            IUnitOfWork unitOfWork
            ) 
    {
        _mapper = mapper;
        _context = context;
        _tokenService = tokenService;
        _passwordService = passwordService;
        _emailService = emailService;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<(Result, User?)> LoginAsync(LoginUserRequestDto request)
    {
        var user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);

        if ( user == null ) {
            return (Result.FailureResult(new List<string> { $"User with email {request.Email} not found" }), null);
        }

        if ( !_passwordService.VerifyPassword(request.Password, user.PasswordHashed) ) {
            return (Result.FailureResult(new List<string> { $"Invalid Password" }), null);
        }

        if ( user.EmailVerified == null ) {
            await SendEmailVerification(user);
            return (Result.FailureResult(new List<string> { $"Email not verified" }), null);
        }

        return (Result.SuccessResult("Login Successful"), user);
    }

    public async Task<Result> RegisterAsync(RegisterUserRequestDto request)
    {
        var findGroup = await _context.Groups.FirstOrDefaultAsync(x => x.ShortName == request.GroupShortName);

        if (findGroup == null)
        {
            _logger.Error($"Group not found");
            return Result.FailureResult(new List<string> { "Group not found" });
        }


        var userExist = await _context.Users.AnyAsync(x => x.Email == request.Email);


        if (userExist)
        {
            _logger.Error($"User with email {request.Email} already exist");
            return Result.FailureResult(new List<string> { $"User with email {request.Email} already exist" });
        }

        var user = _mapper.Map<User>(request);
        user.PasswordHashed = _passwordService.HashPassword(request.Password);
        user.Group = findGroup;

        await _context.Users.AddAsync(user);

        var result = await SendEmailVerification(user);

        if (!result.Success)
        {
            _logger.Error($"Error sending email to {user.Email}");
            return Result.FailureResult(new List<string> { $"Error sending email to {user.Email}" });
        }

        await _context.SaveChangesAsync();


        return Result.SuccessResult("User Registered Successfully");
    }


    private async Task<Result> SendEmailVerification(User user)
    {
        var result = await _unitOfWork.VerificationRepository.GetByUserIdAsync(user.Id);

        if (result != null)
        {
            await _unitOfWork.VerificationRepository.DeleteAsync(result);
        }

        var token = _tokenService.GenerateVerificationToken(user);

        var emailVerification = new Verification
        {
            Token = token,
            User = user,
            UserId = user.Id,
            ExpirationDate = DateTime.UtcNow.AddDays(1),
            VerificationType = VerificationType.EmailVerify
        };

        await _unitOfWork.VerificationRepository.AddAsync(emailVerification);
        await _unitOfWork.CommitAsync();

        var emailHtml = $@"
        <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
            <html xmlns=""http://www.w3.org/1999/xhtml"" lang=""en"">
            <head>
                <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
            </head>
            <body style=""background-color:#ffffff;font-family:-apple-system,BlinkMacSystemFont,'Segoe UI',Roboto,Oxygen-Sans,Ubuntu,Cantarell,'Helvetica Neue',sans-serif"">
                <table align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""max-width:37.5em;margin:0 auto;padding:20px 0 48px;"">
                    <tr style=""width:100%"">
                        <td>
                            <img alt=""ContestCentral"" src=""https://hacks.a2sv.org/assets/A2SV_LOGO%20(2).svg"" width=""170"" height=""50"" style=""display:block;outline:none;border:none;text-decoration:none;margin:0 auto"" />
                            <p style=""font-size:16px;line-height:26px;margin:16px 0;"">Hi {user.FirstName},</p>
                            <p style=""font-size:16px;line-height:26px;margin:16px 0;"">Welcome to ContestCentral, Please confirm your email to continue</p>
                            <table style=""text-align:center"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""100%"">
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href=""http://localhost:5127/api/auth/verifyemail?token={HttpUtility.UrlEncode(token)}"" target=""_blank"" style=""background-color:#5F51E8;border-radius:3px;color:#fff;font-size:16px;text-decoration:none;text-align:center;display:inline-block;padding:12px 12px;line-height:100%;max-width:100%;"">
                                                Confirm Email
                                            </a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <p style=""font-size:16px;line-height:26px;margin:16px 0;"">Best,<br />Contest Central</p>
                            <hr style=""width:100%;border:none;border-top:1px solid #eaeaea;border-color:#cccccc;margin:20px 0;"">
                        </td>
                    </tr>
                </table>
            </body>
        </html>";

        var response = await _emailService.SendAsync(
                new EmailRequest(
                    new string[] {user.Email}, 
                    "ContestCentral - Email Verification", 
                    emailHtml
                    )
                );

        if ( !response.Success ) {
            _logger.Error($"Error sending email to {user.Email}");
        }

        return Result.SuccessResult("Email sent successfully");
    }

    public async Task<Result> VerifyEmailAsync(string code)
    {
        var VerificationRequest = await _unitOfWork.VerificationRepository.GetByTokenAsync(code); 

        if (VerificationRequest == null)
        {
            _logger.Error($"Verification Request not found");
            return Result.FailureResult(new List<string> { "Verification Request not found" });
        }

        if (VerificationRequest.ExpirationDate < DateTime.UtcNow)
        {
            _logger.Error($"Verification Request expired");
            return Result.FailureResult(new List<string> { "Verification Request expired" });
        }

        var user = await _unitOfWork.UserRepository.GetByIdAsync(VerificationRequest.UserId);

        if (user == null)
        {
            _logger.Error($"User not found");
            return Result.FailureResult(new List<string> { "User not found" });
        }

        if (user.Id != VerificationRequest.UserId)
        {
            _logger.Error($"Verification Request not found");
            return Result.FailureResult(new List<string> { "Verification Request not found" });
        }

        user.EmailVerified = DateTime.UtcNow;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.VerificationRepository.DeleteAsync(VerificationRequest);
        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("Email Verified Successfully");
    }

    public async Task<Result> ForgotPasswordAsync(string email)
    {
        var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);

        if (user == null)
        {
            _logger.Error($"User with email {email} not found");
            return Result.FailureResult(new List<string> { $"User with email {email} not found" });
        }

        var token = _tokenService.GenerateVerificationToken(user);

        var emailVerification = new Verification
        {
            Token = token,
            User = user,
            UserId = user.Id,
            ExpirationDate = DateTime.UtcNow.AddDays(1),
            VerificationType = VerificationType.PasswordReset
        };

        await _unitOfWork.VerificationRepository.AddAsync(emailVerification);
        await _unitOfWork.CommitAsync();

        var emailHtml = $@"
        <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
            <html xmlns=""http://www.w3.org/1999/xhtml"" lang=""en"">
            <head>
                <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
            </head>
            <body style=""background-color:#ffffff;font-family:-apple-system,BlinkMacSystemFont,'Segoe UI',Roboto,Oxygen-Sans,Ubuntu,Cantarell,'Helvetica Neue',sans-serif"">
                <table align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""max-width:37.5em;margin:0 auto;padding:20px 0 48px;"">
                    <tr style=""width:100%"">
                        <td>
                            <img alt=""ContestCentral"" src=""https://hacks.a2sv.org/assets/A2SV_LOGO%20(2).svg"" width=""170"" height=""50"" style=""display:block;outline:none;border:none;text-decoration:none;margin:0 auto"" />
                            <p style=""font-size:16px;line-height:26px;margin:16px 0;"">Hi {user.FirstName},</p>
                            <p style=""font-size:16px;line-height:26px;margin:16px 0;"">Please follow the instructions to reset your password</p>
                            <table style=""text-align:center"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""100%"">
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href=""http://localhost:5127/api/auth/resetpassword?token={HttpUtility.UrlEncode(token)}"" target=""_blank"" style=""background-color:#5F51E8;border-radius:3px;color:#fff;font-size:16px;text-decoration:none;text-align:center;display:inline-block;padding:12px 12px;line-height:100%;max-width:100%;"">
                                                Reset Password
                                            </a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <p style=""font-size:16px;line-height:26px;margin:16px 0;"">Best,<br />Contest Central</p>
                            <hr style=""width:100%;border:none;border-top:1px solid #eaeaea;border-color:#cccccc;margin:20px 0;"">
                        </td>
                    </tr>
                </table>
            </body>
        </html>";

        var response = await _emailService.SendAsync(
                new EmailRequest(
                    new string[] {user.Email}, 
                    "ContestCentral - Reset Password", 
                    emailHtml
                    )
                );
        
        if ( !response.Success ) {
            _logger.Error($"Error sending email to {user.Email}");
        }

        return Result.SuccessResult("Email sent successfully");
    }

    public async Task<(Result, User?)> RefreshTokenAsync(string token)
    {
        var dbToken = await _unitOfWork.TokenRepository.GetByTokenAsync(token);

        if ( dbToken == null )
        {
            return (Result.FailureResult(new List<string> { "Invalid Token" }), null);  
        }

        if ( dbToken.Expires < DateTime.UtcNow )
        {
            return (Result.FailureResult(new List<string> { "Token Expired" }), null);  
        }

        var user = await _unitOfWork.UserRepository.GetByIdAsync(dbToken.UserId);

        if ( user == null )
        {
            return (Result.FailureResult(new List<string> { "User not found" }), null);  
        }

        return (Result.SuccessResult("UserValidated"), user);

    }

    public async Task<Result> ResetPasswordAsync(ResetPasswordRequestDto request, string token)
    {
        var VerificationRequest = await _unitOfWork.VerificationRepository.GetByTokenAsync(token);

        if (VerificationRequest == null)
        {
            return Result.FailureResult(new List<string> { "Verification Request not found" });
        }

        if (VerificationRequest.ExpirationDate < DateTime.UtcNow)
        {
            return Result.FailureResult(new List<string> { "Verification Request expired" });
        }

        var user = await _unitOfWork.UserRepository.GetByIdAsync(VerificationRequest.UserId);

        if (user == null)
        {
            return Result.FailureResult(new List<string> { "User not found" });
        }

        user.PasswordHashed = _passwordService.HashPassword(request.newPassword);

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.VerificationRepository.DeleteAsync(VerificationRequest);
        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("Password reset successfully");
    }

    public Task<Result> UpdateProfileAsync(RegisterUserRequestDto request)
    {
        throw new NotImplementedException();
    }

    public Task<Result> getUserProfileAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}
