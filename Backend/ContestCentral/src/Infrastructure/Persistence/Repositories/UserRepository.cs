using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Domain.Common.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContestCentral.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository {
    private readonly ContestCentralDbContext _context;

    public UserRepository(ContestCentralDbContext context) : base(context) {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email) {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserByUserNameAsync(string userName) {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    }
}
