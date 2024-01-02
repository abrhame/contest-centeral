using Domain.Entity;

namespace Application.Interfaces;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<Group?> GetGroupByShortNameAsync(string shortName);
}
