using OffHappit.Application.Features.Authentication.Commands.Registeration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using OffHappit.Application.Features.Authentication.Dtos;

namespace OffHappit.Api.Services;

public class TokenServices : ITokenServices
{
    private readonly IConfiguration _configuration;
    public TokenServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateJwtToken(UserDto user)
    {
        //create a token using the Microsoft.IdentityModel.Tokens
        var secretKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));

        var signingCredentials = new SigningCredentials
            (secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>();

        claims.Add(new Claim("sub", user.UserId.ToString()));
        claims.Add(new Claim("email", user.Email));
        claims.Add(new Claim("given_name", user.FirstName));
        claims.Add(new Claim("family_name", user.LastName));
        claims.Add(new Claim("city", user.City));

        var tokenOptions = new JwtSecurityToken(
            issuer: _configuration["Authentication:Issuer"],
            audience: _configuration["Authentication:Audience"],
            claims,
            DateTime.UtcNow,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Authentication:ExpiryTime"])),
            signingCredentials: signingCredentials
            );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }
}
