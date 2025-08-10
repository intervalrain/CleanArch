namespace CleanArch.Application.Authentication.Dtos;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);