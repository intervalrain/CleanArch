using CleanArch.Api.Mappings;

namespace CleanArch.Api;

public static class CleanArchApiModule
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => {
            cfg.AddProfile<AuthMappingProfile>();
        });

        return services;
    }
}