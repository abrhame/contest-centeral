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
using Infrastructure.Codeforces;

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
        var Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var DbConnectionString = Env == "Production" ? 
            Environment.GetEnvironmentVariable("ContestCentralDbConnectionString") : 
            configuration.GetConnectionString("ContestCentralDbConnection");

        services.AddDbContext<ContestCentralDbContext>(options =>
                options.UseNpgsql(DbConnectionString, b => 
                    b.MigrationsAssembly(typeof(ContestCentralDbContext).Assembly.FullName)));


        services.AddScoped<IContestCentralDbContext>(provider => provider.GetRequiredService<ContestCentralDbContext>());

        var AdminSettings = new AdminSettings();

        if ( Env == "Production" ) 
        {
            AdminSettings.Email = Environment.GetEnvironmentVariable("AdminEmail")!;
            AdminSettings.Password = Environment.GetEnvironmentVariable("AdminPassword")!;
        } 
        else 
        {
            var AdminSettingsSection = configuration.GetSection("AdminSettings");
            configuration.Bind(AdminSettings.SectionName, AdminSettingsSection.Value);
        }

        services.AddSingleton(Options.Create(AdminSettings));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped<ILogger, Logger>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IContestRepository, ContestRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICodeforcesService, CodeforcesService>();

        return services;
    }

    private static IServiceCollection AddEmailServices(this IServiceCollection services, IConfiguration configuration) {
        var Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var emailSettings = new EmailSettings();

        if ( Env == "Production" ) {
            emailSettings.Host = Environment.GetEnvironmentVariable("EmailHost")!;
            emailSettings.Port = int.Parse(Environment.GetEnvironmentVariable("EmailPort")!);
            emailSettings.UserName = Environment.GetEnvironmentVariable("EmailUserName")!;
            emailSettings.Password = Environment.GetEnvironmentVariable("EmailPassword")!;
            emailSettings.DefaultFromEmail = Environment.GetEnvironmentVariable("EmailDefaultFromEmail")!;
        } else {
            configuration.Bind(emailSettings.SectionName, emailSettings);
        }

        services.AddSingleton(Options.Create(emailSettings));
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }

    private static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration) {
        var tokenSettings = new TokenSettings(); 

        var Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        if (Env == "Production") {
            tokenSettings.AccessTokenSecret = Environment.GetEnvironmentVariable("AccessTokenSecret")!;
            tokenSettings.RefreshTokenSecret = Environment.GetEnvironmentVariable("RefreshTokenSecret")!;
            tokenSettings.Issuer = Environment.GetEnvironmentVariable("Issuer")!;
            tokenSettings.Audience = Environment.GetEnvironmentVariable("Audience")!;
        } else {
            configuration.Bind(tokenSettings.SectionName, tokenSettings);
        }

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.AccessTokenSecret)),
                };
            })
            ;

        return services;
    }
}
