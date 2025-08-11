using CleanArch.Application.Authentication;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application;

public static class CleanArchApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => {
            cfg.AddProfile<UserMappingProfile>();
        });

        services.AddMediatR(typeof(CleanArchApplicationModule).Assembly);
        
        return services;
    }
}