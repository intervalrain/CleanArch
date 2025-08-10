using CleanArch.Application.Common.Abstractions;
using CleanArch.Domain.Persistence;
using CleanArch.Infrastructure.Authentication;
using CleanArch.Infrastructure.Persistence;
using CleanArch.Infrastructure.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure;

public static class CleanArchInfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}