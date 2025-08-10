namespace CleanArch.Application.Authentication.Dtos;

public record AuthenticationResult(
    UserDto User,
    string Token);