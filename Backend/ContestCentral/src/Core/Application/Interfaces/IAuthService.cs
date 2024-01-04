using Application.Common.Models;
using Application.DTOs;
using Domain.Entity;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<(Result, User?)> LoginAsync(LoginUserRequestDto request);
    Task<Result> RegisterAsync(RegisterUserRequestDto request);
    Task<Result> VerifyEmailAsync(string code);
    Task<Result> ForgotPasswordAsync( string email );
    Task<Result> ResetPasswordAsync(ResetPasswordRequestDto request, string token);
    Task<(Result, User?)> RefreshTokenAsync(string token);

    Task<Result> UpdateProfileAsync(RegisterUserRequestDto request);
    Task<Result> getUserProfileAsync(Guid userId);
}
