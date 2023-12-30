namespace ContestCentral.Application.Common.Interfaces;

public interface IPasswordServices {
    Task<string> HashPasswordAsync(string password);
    Task<bool> VerifyPasswordAsync(string password, string hashedPassword);
}
