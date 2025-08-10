using CleanArch.Api.Errors;
using CleanArch.Api.Mappings;

using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArch.Api;

public static class CleanArchApiModule
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => {
            cfg.AddProfile<AuthMappingProfile>();
        });
        services.AddSingleton<ProblemDetailsFactory, CleanArchProblemDetailsFactory>();

        return services;
    }
}