using Domain.Entity;

namespace Application.Interfaces;

public interface ILocationRepository : IGenericRepository<Location>
{
    Task<Location?> GetByLocationCodeAsync(string code);
}
