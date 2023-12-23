using Microsoft.AspNetCore.Identity;

namespace ContestCentral.Infrastructure.Identity.Models;

public class ApplicationRole : IdentityRole {
    public ApplicationRole() : base() { }
    public ApplicationRole(string roleName) : base(roleName) { }
    public ApplicationRole(string roleName, string description) : base(roleName) {
        Description = description;
    }

    public string Description { get; set; } = string.Empty;
}

