using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Application.Common.Models;
using ContestCentral.Domain.Common.Entity;
using ContestCentral.Application.Common.DTOs;

using Microsoft.Extensions.Logging;
using AutoMapper;

namespace ContestCentral.Infrastructure.Auth;

public class AuthServices : IAuthService {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IPasswordServices _passwordServices;
    private readonly IEmailService _emailService;
    private readonly ILogger<AuthServices> _logger;
    private readonly IMapper _mapper;

    public AuthServices( 
            IUnitOfWork unitOfWork, 
            ITokenService tokenService, 
            IPasswordServices passwordServices, 
            IEmailService emailService, 
            ILogger<AuthServices> logger, 
            IMapper mapper
            ) {
        _unitOfWork = unitOfWork;
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

        var newUser = new User {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            PasswordHash = passwordHashed,
            EmailVerified = null,
            Role = request.Role,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            accessToken = string.Empty,
            refreshToken = string.Empty
        };

        await _unitOfWork.UserRepository.AddAsync(newUser);

        var emailConfirmationCode = _tokenService.GenerateConfirmationToken(newUser); 

        Console.WriteLine($"User ID: {newUser.Id}");
        await _unitOfWork.EmailConfirmationRepository.AddEmailConfirmationAsync(emailConfirmationCode, newUser.Id);

        var template = $"Confirm your email by clicking <a href=\"https://localhost:5143/api/auth/verifyemail?token={emailConfirmationCode}&userId={newUser.Id}\">here</a>"; 
        var response = await _emailService.SendEmailAsync(
                "aimee.haag6@ethereal.email",
                "Confirm your email",
                template 
                );

        if ( !response.Success ) {
            _logger.LogError($"Error sending email to {newUser.Email}");
        }

        // send email confirmation code to user email

        await _unitOfWork.SaveChangesAsync();

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

        if ( user.EmailVerified == null ) {
            return (Result.FailureResult(new string[] {"Email is not confirmed"}), null);
        }

        if ( !await _passwordServices.VerifyPasswordAsync(request.Password, user.PasswordHash) ) {
            return (Result.FailureResult(new string[] {"Wrong Credentials"}), null);
        }

        var token = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        var response = _mapper.Map<UserDto>(user);

        return (Result.SuccessResult("Login Successful"), 
                new AuthResponseDto(token, refreshToken, DateTime.UtcNow.AddMinutes(15), response)); 
    }

    public async Task<(Result, AuthResponseDto?)> VerifyEmailAsync(string code, Guid userId) {
        var (result, response) = 
            await _unitOfWork.EmailConfirmationRepository.GetEmailConfirmationByCodeAsync(code); 

        if ( !result.Success ) {
            return (result, null);
        }

        if ( response is null ) {
            return (Result.FailureResult(new string[] {"Invalid token"}), null);
        }

        if ( response != code ) {
            return (Result.FailureResult(new string[] {"Invalid token"}), null);
        }

        var user = await _unitOfWork.UserRepository.GetAsync(userId);

        if ( user is null ) {
            return (Result.FailureResult(new string[] {"User not found"}), null);
        }

        var token = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.EmailVerified = DateTime.UtcNow;
        user.accessToken = token;
        user.refreshToken = refreshToken;


        await _unitOfWork.EmailConfirmationRepository.DeleteEmailConfirmationAsync(code);

        await _unitOfWork.SaveChangesAsync();

        

        var res = _mapper.Map<UserDto>(user);

        return (Result.SuccessResult("Verification Successful"), 
                new AuthResponseDto(token, refreshToken, DateTime.UtcNow.AddMinutes(15), res)); 
    }

    public async Task<Result> ForgotPasswordAsync(string email) {
        var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);

        if ( user is null ) {
            return Result.FailureResult(new string[] {"User not found"});
        }

        var code = _tokenService.GenerateConfirmationToken(user);

        var template = $"Reset your password by clicking <a href=\"https://localhost:5001/api/auth/reset-password/{code}\">here</a>";

        var response = await _emailService.SendEmailAsync(
                user.Email,
                "Reset your password",
                template
                );

        if ( !response.Success ) {
            _logger.LogError($"Error sending email to {user.Email}");
        }

        await _unitOfWork.SaveChangesAsync();

        return Result.SuccessResult("Email sent successfully");
    }

    public async Task<Result> ResetPasswordAsync(string newPassword, Guid userId) {
        var user = await _unitOfWork.UserRepository.GetAsync(userId);

        if ( user is null ) {
            return Result.FailureResult(new string[] {"User not found"});
        }

        var passwordHashed = await _passwordServices.HashPasswordAsync(newPassword);

        user.PasswordHash = passwordHashed;

        await _unitOfWork.SaveChangesAsync();

        return Result.SuccessResult("Password reset successfully");
    }
}
