using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork {
    private readonly ContestCentralDbContext _context;
    private UserRepository? _userRepository;
    private EmailConfirmationRepository? _emailConfirmationRepository;

    public UnitOfWork(ContestCentralDbContext context) {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IEmailConfirmationRepository EmailConfirmationRepository => _emailConfirmationRepository ??= new EmailConfirmationRepository(_context);
    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

    public void Dispose() {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
