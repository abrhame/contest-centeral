using Domain.Entity;

namespace Application.Interfaces;

public interface ITokenRepository : IGenericRepository<Token> 
{
    Task<Token?> GetByTokenAsync( string token );
    Task<Token?> GetByUserIdAsync( Guid userId );
}
