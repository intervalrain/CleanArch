using CleanArch.Application.Common.Abstractions;
using CleanArch.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure;

public static class CleanArchInfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}