
using CleanArch.Application.Authentication.Dtos;
using CleanArch.Application.Common.Abstractions;
using CleanArch.Domain.Common.Errors;
using CleanArch.Domain.Persistence;
using CleanArch.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using FluentValidation;

namespace CleanArch.Application.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("'FirstName' must not be empty");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("'LastName' must not be empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("'Email' must not be empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage("'Password' must not be empty");
    }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // 1. Check if user already exists
        if (await _userRepository.GetUserByEmail(request.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create user (generate unique ID) && Persists to DB
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
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
