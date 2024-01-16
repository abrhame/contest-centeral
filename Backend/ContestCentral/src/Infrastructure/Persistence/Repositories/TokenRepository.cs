using Microsoft.EntityFrameworkCore;

using Application.Interfaces;
using Domain.Entity;

namespace Infrastructure.Persistence.Repositories;

public class TokenRepository : GenericRepository<Token>, ITokenRepository
{
    private readonly ContestCentralDbContext _context;
    public TokenRepository( ContestCentralDbContext context ) : base( context ) 
    {
        _context = context;
    }

    public async Task<Token?> GetByTokenAsync( string token )
    {
        return await _context.Tokens
            .Where( t => t.RefreshToken == token )
            .FirstOrDefaultAsync();
    }

    public async Task<Token?> GetByUserIdAsync( Guid userId )
    {
        return await _context.Tokens
            .Where( t => t.UserId == userId )
            .FirstOrDefaultAsync();
    }
}
