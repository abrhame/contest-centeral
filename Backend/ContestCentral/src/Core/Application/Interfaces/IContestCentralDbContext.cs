namespace Application.Interfaces;

public interface IContestCentralDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
