using AutoMapper;
using CleanArch.Application.Authentication.Abstractions;
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Application.Common.Abstractions;
using CleanArch.Domain.Common.Errors;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Persistence;
using ErrorOr;

namespace CleanArch.Application.Authentication.Services;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthenticationResult>> LoginAsync(string email, string password)
    {
        // 1. Validate the user exists
        if (await _userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var userDto = _mapper.Map<UserDto>(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(userDto);

        return new AuthenticationResult(
            userDto,
            token
        );
    }
}