using ContestCentral.Domain.Common.Entity;

namespace ContestCentral.Application.Common.Interfaces;

public interface IUserRepository : IGenericRepository<User> {
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByUserNameAsync(string userName);
    Task<User?> GetUserByCode(string code);
    Task<User?> GetUserByResetToken(string token);
    Task<User?> GetUserByRefreshToken(string token);
}
