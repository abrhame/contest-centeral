using ContestCentral.Domain.Common.Entity;

namespace ContestCentral.Application.Common.Interfaces;

public interface ITokenRepository : IGenericRepository<RefreshToken> {
    Task<RefreshToken?> GetTokenByTokenAsync(string token);
    Task<RefreshToken?> GetTokenByUserIdAsync(Guid userId);
}
