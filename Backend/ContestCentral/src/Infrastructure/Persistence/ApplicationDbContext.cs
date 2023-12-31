using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;

using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Domain.Common.Entity;

namespace ContestCentral.Infrastructure.Persistence;

public class ContestCentralDbContext : DbContext, IContestCentralDbContext {
    public ContestCentralDbContext(DbContextOptions<ContestCentralDbContext> options) : base(options) {}

    public required DbSet<User> Users { get; set; } 
    public required DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminEmail"];
        var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminPassword"];

        modelBuilder.Entity<User>().HasData(
                new User {
                Id = Guid.NewGuid(),
                UserName = "ADMIN",
                Email = adminEmail ?? "admin@a2sv.org",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminPassword),
                Role = Domain.Constants.Role.Administrator,
                Verified = DateTime.UtcNow,
                }
                );
    }
}
