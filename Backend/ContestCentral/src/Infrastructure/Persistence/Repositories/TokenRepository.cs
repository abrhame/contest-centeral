using ContestCentral.Domain.Common.Entity;
using ContestCentral.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace ContestCentral.Infrastructure.Persistence.Repositories;

public class TokenRepository : GenericRepository<RefreshToken>, ITokenRepository {
    private readonly ContestCentralDbContext _context;

    public TokenRepository(ContestCentralDbContext context) : base(context) {
        _context = context;
    }

    public async Task<RefreshToken?> GetTokenByTokenAsync(string token) {
        return await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);
    }

    public async Task<RefreshToken?> GetTokenByUserIdAsync(Guid userId) {
        return await _context.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == userId);
    }
}

