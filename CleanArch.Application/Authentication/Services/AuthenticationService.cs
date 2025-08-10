using AutoMapper;

using CleanArch.Application.Authentication.Abstractions;
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Application.Common.Abstractions;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Persistence;

namespace CleanArch.Application.Authentication.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Check if user already exists
        if (await _userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        // 2. Create user (generate unique ID) && Persists to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        await _userRepository.Add(user);
        var userDto = _mapper.Map<UserDto>(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(userDto);

        return new AuthenticationResult(
            userDto,
            token
        );
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the user exists
        if (await _userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        // 2. Validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
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