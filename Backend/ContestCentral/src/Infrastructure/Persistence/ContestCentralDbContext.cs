using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entity;
using System.Reflection;

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
    }
}
