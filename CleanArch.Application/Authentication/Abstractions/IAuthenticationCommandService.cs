using CleanArch.Application.Authentication.Dtos;

using ErrorOr;

namespace CleanArch.Application.Authentication.Abstractions;

public interface IAuthenticationCommandService
{
    Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password);
}