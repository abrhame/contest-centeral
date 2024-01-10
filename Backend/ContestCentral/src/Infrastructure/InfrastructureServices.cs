using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);
        AddRepositories(services, configuration);
        AddAuthentication(services, configuration);
        AddAuthorization(services, configuration);
        AddCaching(services, configuration);
        AddLogging(services, configuration);
        AddMessaging(services, configuration);
        return services;
    }

    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        //TODO: Change the configuration if environment is in production.

        services.AddOutputCache(options =>
            {
                options.AddBasePolicy( opts =>
                        opts.Expire(TimeSpan.FromMinutes(10))
                        );
            })
            .AddStackExchangeRedisOutputCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("ContestCentralCacheConnection");
                options.InstanceName = "ContestCentralRedisCache";
            });

        return services;
    }


    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
