namespace Application.Interfaces;

public interface IPasswordServices {
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}
