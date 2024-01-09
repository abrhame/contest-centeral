using Application.Interfaces;
using AutoMapper;

namespace Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMapper _mapper;
    private readonly ContestCentralDbContext _context;

    private IGroupRepository? _groupRepository;
    private ILocationRepository? _locationRepository;
    private IContestRepository? _contestRepository;
    private IVerificationRepository? _verificationRepository;
    private IUserRepository? _userRepository;
    private ITokenRepository? _tokenRepository;
    private IQuestionRepository? _questionRepository;

    public UnitOfWork(ContestCentralDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IGroupRepository GroupRepository => _groupRepository ??= new GroupRepository(_context);
    public ILocationRepository LocationRepository => _locationRepository ??= new LocationRepository(_context);
    public IContestRepository ContestRepository => _contestRepository ??= new ContestRepository(_context);
    public IVerificationRepository VerificationRepository => _verificationRepository ??= new VerificationRepository(_context);
    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public ITokenRepository TokenRepository => _tokenRepository ??= new TokenRepository(_context);
    public IQuestionRepository QuestionRepository => _questionRepository ??= new QuestionRepository(_context, _mapper);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
