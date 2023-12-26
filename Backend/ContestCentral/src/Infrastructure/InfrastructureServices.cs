using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using ContestCentral.Infrastructure.Persistence;
using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Infrastructure;

public static class InfrastructureServices {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        {
            var DbConnectionString = configuration.GetConnectionString("ContestCentralDbConnection");

            services.AddDbContext<ContestCentralDbContext>(options =>
                    options.UseNpgsql(DbConnectionString, b => 
                        b.MigrationsAssembly(typeof(ContestCentralDbContext).Assembly.FullName)));

            services.AddScoped<IContestCentralDbContext>(provider => provider.GetRequiredService<ContestCentralDbContext>());
        }

        {

        }
        return services;
    }
}
