using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using app_bk_spotifyList.Services.IServices;
using Microsoft.IdentityModel.Tokens;

namespace app_bk_spotifyList.Services;

public class TokenService : ITokenService
{

    private readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config;
    }
    string ITokenService.GenerateAccessToken(int userId, string email)
    {
        var jwtSettings = _config.GetSection("Jwt");

        var keyString = jwtSettings["Key"];
        if (keyString == null)
            throw new InvalidOperationException("JWT Key no configurado.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));

        var credentials= new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["AccessTokenExpirationMinutes"])),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    

    string ITokenService.GenerateRefreshToken()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}
