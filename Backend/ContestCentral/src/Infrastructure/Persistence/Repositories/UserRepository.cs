using Application.Interfaces;
using Domain.Entity;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ContestCentralDbContext context) : base(context)
    {
    }
}
