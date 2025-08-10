using CleanArch.Application.Authentication;
using CleanArch.Application.Authentication.Abstractions;
using CleanArch.Application.Authentication.Services;

using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application;

public static class CleanArchApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => {
            cfg.AddProfile<UserMappingProfile>();
        });
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}