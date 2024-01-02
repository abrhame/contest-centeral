using Microsoft.EntityFrameworkCore;
using System.Reflection;

using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Domain.Common.Entity;
using ContestCentral.Domain.Entities;

namespace ContestCentral.Infrastructure.Persistence;

public class ContestCentralDbContext : DbContext, IContestCentralDbContext {
    public ContestCentralDbContext(DbContextOptions<ContestCentralDbContext> options) : base(options) {}

    public required DbSet<User> Users { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }
    public DbSet<Attendance> Attendances { get; set; }
}
