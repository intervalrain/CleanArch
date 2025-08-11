using CleanArch.Application.Authentication;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application;

public static class CleanArchApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        UserMappingConfig.Configure();
        services.AddMediatR(typeof(CleanArchApplicationModule).Assembly);
        
        return services;
    }
}