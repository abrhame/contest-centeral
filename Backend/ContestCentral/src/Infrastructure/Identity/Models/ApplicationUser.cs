namespace ContestCentral.Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }

    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }
}
