using BCrypt.Net;

using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Infrastructure.SecurityServices;

public class PasswordService : IPasswordServices {
    public Task<string> HashPasswordAsync(string password) {
        return Task.FromResult(BCrypt.Net.BCrypt.HashPassword(password));
    }

    public Task<bool> VerifyPasswordAsync(string candidatePassword, string hashedPassword) {
        return Task.FromResult(BCrypt.Net.BCrypt.Verify(candidatePassword, hashedPassword));
    }
}
