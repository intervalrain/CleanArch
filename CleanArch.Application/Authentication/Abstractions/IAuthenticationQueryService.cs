using CleanArch.Application.Authentication.Dtos;

using ErrorOr;

namespace CleanArch.Application.Authentication.Abstractions;

public interface IAuthenticationQueryService
{
    Task<ErrorOr<AuthenticationResult>> LoginAsync(string email, string password);
}