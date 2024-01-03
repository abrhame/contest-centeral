using Microsoft.EntityFrameworkCore;

using Application.Interfaces;
using Domain.Entity;

namespace Infrastructure.Persistence.Repositories;

public class LocationRepository : GenericRepository<Location>, ILocationRepository
{
    private readonly ContestCentralDbContext _context;

    public LocationRepository(ContestCentralDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Location?> GetByLocationCodeAsync(string code)
    {
        return await _context.Locations.FirstOrDefaultAsync(x => x.ShortName == code);
    }

    public async Task<Location?> GetByUniversityNameAsync(string name)
    {
        return await _context.Locations.FirstOrDefaultAsync(x => x.University == name);
    }
}
