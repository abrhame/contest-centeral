namespace ContestCentral.Application.Common.Interfaces;

public interface IContestCentralDbContext {
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
