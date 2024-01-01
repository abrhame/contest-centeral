using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Infrastructure.Persistence.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    private readonly ContestCentralDbContext _context;

    public GroupRepository(ContestCentralDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Group?> GetGroupByShortNameAsync(string shortName)
    {
        return await _context.Groups.FirstOrDefaultAsync(x => x.ShortName == shortName);
    }
} 
