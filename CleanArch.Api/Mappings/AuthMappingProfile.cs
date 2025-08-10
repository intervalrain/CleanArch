using AutoMapper;
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Contracts.Authentication;

namespace CleanArch.Api.Mappings;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<AuthenticationResult, AuthenticationResponse>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.User.Id))
            .ForCtorParam("FirstName", opt => opt.MapFrom(src => src.User.FirstName))
            .ForCtorParam("LastName", opt => opt.MapFrom(src => src.User.LastName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.User.Email))
            .ForCtorParam("Token", opt => opt.MapFrom(src => src.Token));
    }
}