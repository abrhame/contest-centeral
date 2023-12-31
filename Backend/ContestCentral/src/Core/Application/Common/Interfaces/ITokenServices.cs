using ContestCentral.Domain.Common.Entity; 

namespace ContestCentral.Application.Common.Interfaces;

public interface ITokenService {
    public string GenerateAccessToken(User user);
    public (Guid, string) GenerateRefreshToken();
    public Guid? ValidateToken(string refreshtoken, out Guid tokenId);
    public string GenerateVerificationToken(User user);
}
