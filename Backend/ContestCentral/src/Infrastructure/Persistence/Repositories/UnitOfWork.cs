using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork {
    private readonly ContestCentralDbContext _context;
    private UserRepository? _userRepository;
    private TokenRepository? _tokenRepository;

    public UnitOfWork(ContestCentralDbContext context) {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public ITokenRepository TokenRepository => _tokenRepository ??= new TokenRepository(_context);

    public void Dispose() {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
