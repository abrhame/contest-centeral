namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGroupRepository GroupRepository { get; }
    ILocationRepository LocationRepository { get; }
    IContestRepository ContestRepository { get; }
    IVerificationRepository VerificationRepository { get; }
    IUserRepository UserRepository { get; }
    ITokenRepository TokenRepository { get; }

    Task CommitAsync();
}
