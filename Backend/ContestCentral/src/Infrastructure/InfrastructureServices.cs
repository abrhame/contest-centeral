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
using ContestCentral.Infrastructure.Email;
using ContestCentral.Infrastructure.Auth;
using ContestCentral.Infrastructure.Persistence.Repositories;

namespace ContestCentral.Infrastructure;

public static class InfrastructureServices {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddRepositories(configuration);
        services.AddPersistenceServices(configuration);
        services.AddEmailServices(configuration);
        services.AddAuthenticationServices(configuration);
        services.AddSecurityServices(configuration);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenRepository, TokenRepository>();

        return services;
    }

    private static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IPasswordServices, PasswordService>();

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
        var emailSettings = new EmailSettings();

        configuration.Bind(emailSettings.SectionName, emailSettings);

        services.AddSingleton(Options.Create(emailSettings));

        services.AddTransient<IEmailService, EmailService>();

        return services;
    }

    private static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration) {
        var tokenSettings = new TokenSettings();

        configuration.Bind(tokenSettings.SectionName, tokenSettings);

        services.AddSingleton(Options.Create(tokenSettings));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthServices>();

        services.AddAuthentication(
                options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenSettings.Issuer,
                    ValidAudience = tokenSettings.Audience, 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret)),
                };
            })
            ;

        return services;
    }
}
