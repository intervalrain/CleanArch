using AutoMapper;
using CleanArch.Application.Authentication.Abstractions;
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Application.Common.Abstractions;
using CleanArch.Domain.Common.Errors;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Persistence;
using ErrorOr;

namespace CleanArch.Application.Authentication.Services;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        // 1. Check if user already exists
        if (await _userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
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
}