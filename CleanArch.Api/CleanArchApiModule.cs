using System.Reflection;
using CleanArch.Api.Common.Errors;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArch.Api;

public static class CleanArchApiModule
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CleanArchProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }

    private static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();

        return services;
    }
}