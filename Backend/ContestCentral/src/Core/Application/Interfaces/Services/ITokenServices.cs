using Domain.Entity;

namespace Application.Interfaces;

public interface ITokenServices 
{
    string GenerateAccessToken( User user );
    (Guid, string) GenerateRefreshToken();
    bool ValidateToken( string token, out Guid tokenId );
    string GenerateVerificationToken( User user );
    bool ValidateAccessToken(string token, out Guid userId);
}
