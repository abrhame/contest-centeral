using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Common.Interfaces; 

public interface IAuthServices {
    Task<(Result, string)> RegisterAsync(RegisterUserRequestDto request);
    Task<(Result, string)> LoginAsync(LoginUserRequestDto request);
    Task<(Result, string)> RefreshTokenAsync(string token);
    Task<bool> RevokeTokenAsync(string token);
}
