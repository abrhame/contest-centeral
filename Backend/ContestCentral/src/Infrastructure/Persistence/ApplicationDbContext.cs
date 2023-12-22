using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

using ContestCentral.Application.Interfaces;
using ContestCentral.Infrastructure.Identity.Models;

namespace ContestCentral.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder builder) {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
