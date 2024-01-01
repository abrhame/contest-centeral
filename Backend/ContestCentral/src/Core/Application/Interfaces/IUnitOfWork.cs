namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGroupRepository GroupRepository { get; }
    ILocationRepository LocationRepository { get; }
    IContestRepository ContestRepository { get; }

    Task CommitAsync();
}
