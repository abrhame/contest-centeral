using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Application.Common.Models;
using ContestCentral.Domain.Common.Entity;
using ContestCentral.Application.Common.DTOs;
using ContestCentral.Infrastructure.Persistence;

using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Web;

namespace ContestCentral.Infrastructure.Auth;

public class AuthServices : IAuthService {
    private readonly ITokenService _tokenService;
    private readonly IPasswordServices _passwordServices;
    private readonly IEmailService _emailService;
    private readonly ILogger<AuthServices> _logger;
    private readonly IMapper _mapper;
    private readonly ContestCentralDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public AuthServices( 
            IUnitOfWork unitOfWork,
            ContestCentralDbContext context,
            ITokenService tokenService, 
            IPasswordServices passwordServices, 
            IEmailService emailService, 
            ILogger<AuthServices> logger, 
            IMapper mapper
            ) {
        _unitOfWork = unitOfWork;
        _context = context;
        _tokenService = tokenService;
        _passwordServices = passwordServices;
        _emailService = emailService;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result> RegisterAsync(RegisterUserRequestDto request) {
        if ( request.Email is null || request.Password is null ) {
            return Result.FailureResult(new string[] {"Email or password cannot be null"});
        }

        var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);

        if ( user != null ) {
            return Result.FailureResult(new string[] {"User already exists"});
        };

        var passwordHashed = await _passwordServices.HashPasswordAsync(request.Password);

        var newUser = _mapper.Map<User>(request); 
        newUser.PasswordHash = passwordHashed;

        await _unitOfWork.UserRepository.AddAsync(newUser);

        var result = await SendEmailVerificationAsync(newUser);

        if ( !result.Success ) {
            _logger.LogError($"Error sending email to {newUser.Email}");
        }

        return Result.SuccessResult("User created successfully");
    }

    public async Task<(Result, AuthResponseDto?)> LoginAsync(LoginUserRequestDto request) {
        if ( request.Email is null || request.Password is null ) {
            return (Result.FailureResult(new string[] {"Email or password cannot be null"}), null);
        }

        var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);

        if ( user is null ) {
            return (Result.FailureResult(new string[] {"User does not exist"}), null);
        };

        if ( !user.IsVerified ) {
            return (Result.FailureResult(new string[] {"Email is not confirmed"}), null);
        }

        if ( !await _passwordServices.VerifyPasswordAsync(request.Password, user.PasswordHash) ) {
            return (Result.FailureResult(new string[] {"Wrong Credentials"}), null);
        }

        var token = _tokenService.GenerateAccessToken(user);

        var (tokenId, refreshToken) = _tokenService.GenerateRefreshToken();

        var tokenExists = await _unitOfWork.TokenRepository.GetTokenByUserIdAsync(user.Id);

        if ( tokenExists != null ) {
            await _unitOfWork.TokenRepository.DeleteAsync(tokenExists);
        }

        await _unitOfWork.TokenRepository.AddAsync(new RefreshToken {
            Id = tokenId,
            UserId = user.Id,
            Token = refreshToken,
            Expires = DateTime.UtcNow.AddDays(7),
        });

        var response = _mapper.Map<UserDto>(user);

        return (Result.SuccessResult("Login Successful"), 
                new AuthResponseDto(token, response, refreshToken)); 
    }

    public async Task<Result> VerifyEmailAsync(string code) {
        var account = await _unitOfWork.UserRepository.GetUserByCode(code);

        if ( account is null ) {
            return Result.FailureResult(new string[] {"Invalid token"});
        }

        account.Verified = DateTime.UtcNow;
        account.VerificationToken = string.Empty;

        await _unitOfWork.UserRepository.UpdateAsync(account);

        return Result.SuccessResult("Email confirmed successfully");
    }

    public async Task<Result> ForgotPasswordAsync(string email) {
        var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);

        if ( user is null ) {
            return Result.FailureResult(new string[] {"User not found"});
        }

        user.ResetToken = _tokenService.GenerateVerificationToken(user);
        user.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

        await _unitOfWork.UserRepository.UpdateAsync(user);

        var result = await SendPasswordResetEmailAsync(user);

        if ( !result.Success ) {
            _logger.LogError($"Error sending email to {user.Email}");
            return Result.FailureResult(new string[] {"Error sending email"});
        }

        return Result.SuccessResult("Password reset email sent successfully");
    }

    public async Task<Result> ResetPasswordAsync(string token, ResetPasswordRequestDto request) {
        var user = await _unitOfWork.UserRepository.GetUserByResetToken(token);

        if ( user is null ) {
            return Result.FailureResult(new string[] {"User not found"});
        }

        var passwordHashed = await _passwordServices.HashPasswordAsync(request.newPassword);

        user.PasswordHash = passwordHashed;
        user.ResetToken = string.Empty;
        user.ResetTokenExpires = null;

        await _unitOfWork.UserRepository.UpdateAsync(user);

        return Result.SuccessResult("Password reset successfully");
    }

    public async Task<(Result, AuthResponseDto?)> RefreshTokenAsync(string token) {
        var userId = _tokenService.ValidateToken(token, out Guid tokenId);

        if ( userId is null ) {
            return (Result.FailureResult(new string[] {"Invalid token"}), null);
        }

        var refreshToken = await _unitOfWork.TokenRepository.GetAsync(tokenId);

        if ( refreshToken is null ) {
            return (Result.FailureResult(new string[] {"Invalid token"}), null);
        }

        if ( refreshToken.Expires < DateTime.UtcNow ) {
            return (Result.FailureResult(new string[] {"Token expired"}), null);
        }

        var user = await _unitOfWork.UserRepository.GetAsync(refreshToken.UserId);

        if ( user is null ) {
            return (Result.FailureResult(new string[] {"User not found"}), null);
        }

        var newToken = _tokenService.GenerateAccessToken(user);

        var response = _mapper.Map<UserDto>(user);

        return (Result.SuccessResult("Token refreshed successfully"), 
                new AuthResponseDto(newToken, response, refreshToken.Token));
    }


    public async Task<Result> SendEmailVerificationAsync(User user) {
        var token = _tokenService.GenerateVerificationToken(user);
        
        user.VerificationToken = token;
        await _unitOfWork.UserRepository.UpdateAsync(user);

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
                                            <a href=""http://localhost:5143/api/auth/verifyemail?token={HttpUtility.UrlEncode(token)}"" target=""_blank"" style=""background-color:#5F51E8;border-radius:3px;color:#fff;font-size:16px;text-decoration:none;text-align:center;display:inline-block;padding:12px 12px;line-height:100%;max-width:100%;"">
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

        var response = await _emailService.SendEmailAsync(
                user.Email,
                "Confirm your email",
                emailHtml,
                null
                );

        if ( !response.Success ) {
            _logger.LogError($"Error sending email to {user.Email}");
        }

        return Result.SuccessResult("Email sent successfully");
    }


    public async Task<Result> SendPasswordResetEmailAsync(User user) {
        var token = _tokenService.GenerateVerificationToken(user);

        user.ResetToken = token;
        await _unitOfWork.UserRepository.UpdateAsync(user);

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
                            <table style=""text-align:center"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""100%"">
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href=""http://localhost:5143/api/auth/resetpassword?token={HttpUtility.UrlEncode(token)}"" target=""_blank"" style=""background-color:#5F51E8;border-radius:3px;color:#fff;font-size:16px;text-decoration:none;text-align:center;display:inline-block;padding:12px 12px;line-height:100%;max-width:100%;"">
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

        var response = await _emailService.SendEmailAsync(
                user.Email,
                "Confirm your email",
                emailHtml,
                null
                );

        if ( !response.Success ) {
            _logger.LogError($"Error sending email to {user.Email}");
        }

        return Result.SuccessResult("Email sent successfully");
    }
}
