using ContestCentral.Application.Common.DTOs;
using ContestCentral.Domain.Common.Entity;
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Common.Interfaces; 

public interface IAuthService {
    Task<Result> RegisterAsync(RegisterUserRequestDto request);
    Task<(Result, AuthResponseDto?)> LoginAsync(LoginUserRequestDto request);
    Task<Result> VerifyEmailAsync(string token);
    Task<Result> ForgotPasswordAsync(string email);
    Task<Result> ResetPasswordAsync(string token, ResetPasswordRequestDto request);
    Task<(Result, AuthResponseDto?)> RefreshTokenAsync(string token);
    Task<Result> SendEmailVerificationAsync(User user);
    Task<Result> SendPasswordResetEmailAsync(User user);
}
