using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using ContestCentral.Infrastructure.Persistence;
using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Infrastructure.SecurityServices;
using ContestCentral.Infrastructure.Tokens;
using ContestCentral.Infrastructure.Persistence.Repositories;

namespace ContestCentral.Infrastructure;

public static class InfrastructureServices {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddPersistenceServices(configuration);
        services.AddEmailServices(configuration);
        services.AddAuthenticationServices(configuration);
        services.AddSecurityServices(configuration);
        services.AddRepositories(configuration);

        return services;
    }

    private static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IPasswordServices, PasswordService>();

        return services;
    }


    private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        {
            var DbConnectionString = configuration.GetConnectionString("ContestCentralDbConnection");

            services.AddDbContext<ContestCentralDbContext>(options =>
                    options.UseNpgsql(DbConnectionString, b => 
                        b.MigrationsAssembly(typeof(ContestCentralDbContext).Assembly.FullName)));

            services.AddScoped<IContestCentralDbContext>(provider => provider.GetRequiredService<ContestCentralDbContext>());
        }

        return services;
    }

    private static IServiceCollection AddEmailServices(this IServiceCollection services, IConfiguration configuration) {
        return services;
    }

    private static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration) {
        var tokenSettings = new TokenSettings();

        configuration.Bind(tokenSettings.SectionName, tokenSettings);

        services.AddSingleton(Options.Create(tokenSettings));
        services.AddScoped<ITokenService, TokenService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenSettings.Issuer,
                    ValidAudience = tokenSettings.Audience, 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret)),
                };
            });

        return services;
    }
}
