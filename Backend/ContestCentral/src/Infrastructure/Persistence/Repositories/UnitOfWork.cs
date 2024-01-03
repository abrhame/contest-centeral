using Application.Interfaces;

namespace Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ContestCentralDbContext _context;

    private IGroupRepository? _groupRepository;
    private ILocationRepository? _locationRepository;
    private IContestRepository? _contestRepository;
    private IVerificationRepository? _verificationRepository;
    private IUserRepository? _userRepository;

    public UnitOfWork(ContestCentralDbContext context)
    {
        _context = context;
    }

    public IGroupRepository GroupRepository => _groupRepository ??= new GroupRepository(_context);
    public ILocationRepository LocationRepository => _locationRepository ??= new LocationRepository(_context);
    public IContestRepository ContestRepository => _contestRepository ??= new ContestRepository(_context);
    public IVerificationRepository VerificationRepository => _verificationRepository ??= new VerificationRepository(_context);
    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
