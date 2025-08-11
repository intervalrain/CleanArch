using AutoMapper;
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Application.Common.Abstractions;
using CleanArch.Domain.Common.Errors;
using CleanArch.Domain.Persistence;
using CleanArch.Domain.Entities;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Authentication.Queries;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // 1. Validate the user exists
        if (await _userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct
        if (user.Password != request.Password)
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