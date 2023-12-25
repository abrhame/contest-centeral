using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServices {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly()); 

        return services;
    }
}
