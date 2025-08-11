using AutoMapper;
using CleanArch.Application.Authentication.Abstractions;
using CleanArch.Contracts.Authentication;
using CleanArch.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationQueryService _authenticationQueryService;
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationQueryService authenticationQueryService, IAuthenticationCommandService authenticationCommandService, IMapper mapper)
    {
        _authenticationQueryService = authenticationQueryService;
        _authenticationCommandService = authenticationCommandService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authenticationCommandService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Password);

        return result.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _authenticationQueryService.LoginAsync(request.Email, request.Password);

        if (result.IsError && result.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: result.FirstError.Description
            );
        }

        return result.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}