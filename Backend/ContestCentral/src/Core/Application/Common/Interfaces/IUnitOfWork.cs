namespace ContestCentral.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable {
    IUserRepository UserRepository { get; }
    ITokenRepository TokenRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
