// using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
// using ContestCentral.Application.Profiles;

public static class ApplicationServices {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
