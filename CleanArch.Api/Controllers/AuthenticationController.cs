using AutoMapper;

using CleanArch.Application.Authentication.Abstractions;
using CleanArch.Contracts.Authentication;

using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var response = _mapper.Map<AuthenticationResponse>(result);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _authenticationService.Login(request.Email, request.Password);

        var response = _mapper.Map<AuthenticationResponse>(result);

        return Ok(response);
    }
}