using CleanArch.Api.Mappings;
using CleanArch.Api.Middleware;

namespace CleanArch.Api;

public static class CleanArchApiModule
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => {
            cfg.AddProfile<AuthMappingProfile>();
        });
        services.AddScoped<ErrorHandlingMiddleware>();

        return services;
    }
}