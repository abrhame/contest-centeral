using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Infrastructure.SecurityServices;

public class PasswordHashService : IPasswordServices {
    public Task<string> HashPasswordAsync(string password) {
        throw new NotImplementedException();
        // return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public Task<bool> VerifyPasswordAsync(string candidatePassword, string hashedPassword) {
        throw new NotImplementedException();
        // try
        // {
        //     return BCrypt.Net.BCrypt.Verify(candidatePassword, hashedPassword);
        // }
        // catch (Exception)
        // {
        //     return false;
        // }
    }
}
