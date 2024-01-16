using Application.Common.Models;
using Application.DTOs;
using Domain.Entity;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<(Result, User?)> LoginAsync(AuthRequestDto request);
    Task<Result> RegisterAsync(CreateUserRequestDto request);
    Task<Result> VerifyEmailAsync(string code);
    Task<Result> ForgotPasswordAsync( string email );
    Task<Result> ResetPasswordAsync(ResetPasswordRequestDto request, string token);
    Task<(Result, User?)> RefreshTokenAsync(string token);

    Task<Result> UpdateProfileAsync(UpdateUserRequestDto request);
    Task<Result> getUserProfileAsync(Guid userId);
}
