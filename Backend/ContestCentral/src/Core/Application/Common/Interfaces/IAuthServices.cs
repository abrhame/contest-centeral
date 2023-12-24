using ContestCentral.Application.Common

public interface IAuthServices {
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task<AuthResponse> RefreshTokenAsync(string token);
    Task<bool> RevokeTokenAsync(string token);
}
