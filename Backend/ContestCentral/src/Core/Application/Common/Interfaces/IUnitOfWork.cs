namespace ContestCentral.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable {
    IUserRepository UserRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
