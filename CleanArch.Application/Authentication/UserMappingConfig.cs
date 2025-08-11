using CleanArch.Application.Authentication.Dtos;
using CleanArch.Domain.Entities;
using System.Reflection;
using Mapster;

namespace CleanArch.Application.Authentication;

public class UserMappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        TypeAdapterConfig.GlobalSettings.ForType<User, UserDto>();
    }
}