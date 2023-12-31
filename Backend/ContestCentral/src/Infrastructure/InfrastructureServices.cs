using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Infrastructure.Persistence;
using Application.Interfaces;

namespace Infrastructure;

public static class InfrastructureServices {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddPersistenceServices(configuration);

        return services;
    }

    private static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        var DbConnectionString = configuration.GetConnectionString("ContestCentralDbConnection");

        services.AddDbContext<ContestCentralDbContext>(options =>
                options.UseNpgsql(DbConnectionString, b => 
                    b.MigrationsAssembly(typeof(ContestCentralDbContext).Assembly.FullName)));


        services.AddScoped<IContestCentralDbContext>(provider => provider.GetRequiredService<ContestCentralDbContext>());
    }
}
