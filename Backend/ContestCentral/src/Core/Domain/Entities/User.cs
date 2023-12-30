using ContestCentral.Domain.Constants;

namespace ContestCentral.Domain.Common.Entity;

public class User : BaseEntity<Guid> {
    public string FirstName { get; set; } = string.Empty;    
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? EmailVerified { get; set; } = null!;
    public string AvatarUrl { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public Role Role { get; set; } = Role.Student;
    
    public string PasswordHash { get; set; } = string.Empty;

    public string accessToken { get; set; } = string.Empty;
    public string refreshToken { get; set; } = string.Empty;
}

