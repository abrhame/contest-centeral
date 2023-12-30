using ContestCentral.Domain.Common.Entity; 

namespace ContestCentral.Application.Common.Interfaces;

public interface ITokenService {
    public string GenerateAccessToken(User user);
    public string GenerateRefreshToken();
    public string GenerateConfirmationToken(User user);
    public string ValidateToken(string token);
}
