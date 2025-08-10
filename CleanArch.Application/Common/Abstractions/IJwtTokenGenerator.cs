namespace CleanArch.Application.Common.Abstractions;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName);
}