using MediatR;

using Application.Common.Models;
using Application.DTOs;
using Domain.Entity;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<(Result, User?)> LoginAsync(LoginUserRequestDto request);
    Task<Result> RegisterAsync(RegisterUserRequestDto request);
    Task<Unit> LogoutAsync();
    Task<Result> VerifyEmailAsync(string code);
    Task<Result> ForgotPasswordAsync( string email );
    Task<Result> ResetPasswordAsync(ResetPasswordRequestDto request);

    Task<Result> UpdateProfileAsync(RegisterUserRequestDto request);
    Task<Result> getUserProfileAsync(Guid userId);
}
