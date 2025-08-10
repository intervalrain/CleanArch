using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CleanArch.Application.Common.Abstractions;

namespace CleanArch.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-super-super-super-secret-key")),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var jwtToken = new JwtSecurityToken(
            issuer: "CleanArch",
            audience: "CleanArch",
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}