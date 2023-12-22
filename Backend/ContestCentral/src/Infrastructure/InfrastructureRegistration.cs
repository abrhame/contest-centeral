using ContestCentral.Application.Interfaces;
using ContestCentral.Infrastructure.Identity.Models;
using ContestCentral.Infrastructure.Persistence;
using ContestCentral.Infrastructure.Identity;
using ContestCentral.Domain.Constants;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace ContestCentral.Infrastructure;

public static class InfrasturctureRegistration {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();


        services.AddAuthorization(options => {
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator));
            options.AddPolicy(Policies.CanManageHeadsOfEducation, policy => policy.RequireRole(Roles.Administrator));
            options.AddPolicy(Policies.CanManageStudents, policy => policy.RequireRole(Roles.Administrator));
            options.AddPolicy(Policies.CanManageContests, policy => policy.RequireRole(Roles.ContestCreator));
            });
        
        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        return services;
    }

}
