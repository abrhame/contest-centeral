using Domain.Entity;

namespace Application.Interfaces;

public interface ITokenService {
    string GenerateAccessToken( User user );
    (Guid, string) GenerateRefreshToken();
    Guid? ValidateToken( string token, out Guid userId );
    string GenerateVerificationToken( User user );
}
