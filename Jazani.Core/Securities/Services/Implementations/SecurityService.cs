using Jazani.Core.Securities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jazani.Core.Securities.Services.Implementations;
public class SecurityService : ISecurityService
{
    public string HashPassword(string userName, string hashedPassword)
    {
        PasswordHasher<string> passwordHasher = new();

        return passwordHasher.HashPassword(userName, hashedPassword);
    }

    public bool VerifyHashedPassword(string userName, string hashedPassword, string providedPassword)
    {
        PasswordHasher<string> passwordHasher = new();

        PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(userName, hashedPassword, providedPassword);

        return (result == PasswordVerificationResult.Success);
    }

    public SecurityEntity JwtSecurity(string jwtSecrectKey)
    {
        DateTime utcNow = DateTime.UtcNow;

        List<Claim> claims = new() { 
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
        };

        DateTime expireDatetime = utcNow.AddDays(1);

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

        //key + credentials
        byte[] key = Encoding.ASCII.GetBytes(jwtSecrectKey);
        SymmetricSecurityKey symmetricSecurityKey = new(key);
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new(
            claims: claims,
            expires: expireDatetime,
            notBefore: utcNow,
            signingCredentials: signingCredentials
            );

        return new() { 
            TokenType = "Bearer",
            AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken),
            ExpireOn = expireDatetime
        };
    }
}
