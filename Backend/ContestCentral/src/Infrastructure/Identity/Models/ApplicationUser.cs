using Microsoft.AspNetCore.Identity;

namespace ContestCentral.Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }
}
