using CleanArch.Application.Authentication.Dtos;

namespace CleanArch.Application.Authentication.Abstractions;

public interface IAuthenticationService
{
    Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    Task<AuthenticationResult> Login(string email, string password);
}