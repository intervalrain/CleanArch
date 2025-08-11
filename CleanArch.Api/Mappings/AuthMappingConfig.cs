using CleanArch.Application.Authentication.Commands;
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Application.Authentication.Queries;
using CleanArch.Contracts.Authentication;
using System.Reflection;
using Mapster;

namespace CleanArch.Api.Mappings;

public class AuthMappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        TypeAdapterConfig.GlobalSettings.ForType<RegisterRequest, RegisterCommand>();
        TypeAdapterConfig.GlobalSettings.ForType<LoginRequest, LoginQuery>();

        TypeAdapterConfig.GlobalSettings.ForType<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.Token, src => src.Token);
    }
}