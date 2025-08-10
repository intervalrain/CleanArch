using CleanArch.Application.Authentication.Dtos;

namespace CleanArch.Application.Common.Abstractions;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserDto user);
}