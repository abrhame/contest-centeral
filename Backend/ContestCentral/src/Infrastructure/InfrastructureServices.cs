using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;

using Infrastructure.Email;
using Infrastructure.Tokens;
using Application.Interfaces;
using Infrastructure.Auth;
using Infrastructure.Password;
using Infrastructure.Logging;

namespace Infrastructure;

public static class InfrastructureServices {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddPersistenceServices(configuration);
        services.AddRepositories();
        services.AddEmailServices(configuration);
        services.AddAuthenticationServices(configuration);

        return services;
    }

    private static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        var DbConnectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ContestCentralDbContext>(options =>
                options.UseNpgsql(DbConnectionString, b => 
                    b.MigrationsAssembly(typeof(ContestCentralDbContext).Assembly.FullName)));


        services.AddScoped<IContestCentralDbContext>(provider => provider.GetRequiredService<ContestCentralDbContext>());

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped<ILogger, Logger>();
        services.AddScoped<IContestRepository, ContestRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

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
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordService, PasswordService>();

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