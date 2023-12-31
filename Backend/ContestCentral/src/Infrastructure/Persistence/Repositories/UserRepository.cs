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

    public async Task<User?> GetUserByCode(string code) {
        return await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == code);
    }

    public async Task<User?> GetUserByResetToken(string token) {
        return await _context.Users.FirstOrDefaultAsync(u => u.ResetToken == token);
    }

    public async Task<User?> GetUserByRefreshToken(string token) {
        return await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken != null && (u.RefreshToken.Token == token));
    }
}
