namespace CleanArch.Application.Authentication.Dtos;

public record UserDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email);