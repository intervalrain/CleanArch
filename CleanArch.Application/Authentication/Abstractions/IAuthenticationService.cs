using CleanArch.Application.Authentication.Dtos;

using ErrorOr;

namespace CleanArch.Application.Authentication.Abstractions;

public interface IAuthenticationService
{
    Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password);
    Task<ErrorOr<AuthenticationResult>> LoginAsync(string email, string password);
}