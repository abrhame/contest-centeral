using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Common.Interfaces; 

public interface IAuthService {
    Task<Result> RegisterAsync(RegisterUserRequestDto request);
    Task<(Result, AuthResponseDto?)> LoginAsync(LoginUserRequestDto request);
    Task<(Result, AuthResponseDto?)> VerifyEmailAsync(string token, Guid userId);
    Task<Result> ForgotPasswordAsync(string email);
    Task<Result> ResetPasswordAsync(string newPassword, Guid userId);
}
