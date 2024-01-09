using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entity;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence;

public class ContestCentralDbContext : DbContext, IContestCentralDbContext 
{
    public ContestCentralDbContext(DbContextOptions<ContestCentralDbContext> options) : base(options) {}

    public required DbSet<User> Users { get; set; }
    public required DbSet<Team> Teams { get; set; }
    public required DbSet<Contest> Contests { get; set; }

    public required DbSet<Group> Groups { get; set; }
    public required DbSet<Question> Questions { get; set; }

    public required DbSet<Submission> TeamSubmissions { get; set; }

    public required DbSet<Location> Locations { get; set; }
    public required DbSet<Tags> Tags { get; set; }

    public required DbSet<Verification> Verifications { get; set; }
    public required DbSet<Token> Tokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        var AdminSettings = new AdminSettings();

        if ( Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production" ) 
        {
            AdminSettings.Email = Environment.GetEnvironmentVariable("AdminEmail")!;
            AdminSettings.Password = Environment.GetEnvironmentVariable("AdminPassword")!;
        } 
        else 
        {
            var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminSettings")["Email"];
            var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminSettings")["Password"];

            AdminSettings.Email = adminEmail!;
            AdminSettings.Password = adminPassword!;
        }

        // seed data for admin user
        
        var id = Guid.NewGuid();

        modelBuilder.Entity<Location>().HasData(
            new Location 
            {
                Id = id,
                City = "Addis Ababa",
                Country = "Ethiopia",
                University = "Addis Ababa Science and Technology University",
            }
        );

        var groupid = Guid.NewGuid();

        modelBuilder.Entity<Group>().HasData(
            new Group 
            { 
                Id = groupid,
                Name = "Group A",
                LocationId = id
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User 
            {
                Id = Guid.NewGuid(),
                Email = AdminSettings.Email,
                PasswordHashed = BCrypt.Net.BCrypt.HashPassword(AdminSettings.Password),
                FirstName = "Admin",
                LastName = "Admin",
                Role = Domain.Constant.Role.Administrator,
                GroupId = groupid
            }
        );

    }
}
