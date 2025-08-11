using CleanArch.Api.Common.Errors;
using CleanArch.Api.Mappings;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArch.Api;

public static class CleanArchApiModule
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        AuthMappingConfig.Configure();
        services.AddSingleton<IMapper, Mapper>();
        services.AddSingleton<ProblemDetailsFactory, CleanArchProblemDetailsFactory>();

        return services;
    }
}