using CleanArch.Application.Authentication.Commands;
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Application.Authentication.Queries;
using CleanArch.Contracts.Authentication;
using CleanArch.Domain.Entities;
using Mapster;

namespace CleanArch.Api.Common.Mappings;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<User, UserDto>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}