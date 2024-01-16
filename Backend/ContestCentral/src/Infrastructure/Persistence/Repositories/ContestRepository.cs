using Application.Interfaces;
using Domain.Entity;

namespace Infrastructure.Persistence.Repositories;

public class ContestRepository : GenericRepository<Contest>, IContestRepository
{
    private readonly ContestCentralDbContext _context;

    public ContestRepository(ContestCentralDbContext context) : base(context)
    {
        _context = context;
    }
}
