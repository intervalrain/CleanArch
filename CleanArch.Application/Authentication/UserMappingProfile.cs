using AutoMapper;
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Authentication;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}