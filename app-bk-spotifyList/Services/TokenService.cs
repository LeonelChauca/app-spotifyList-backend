using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using app_bk_spotifyList.Models.Dtos.RefreshToken;
using app_bk_spotifyList.Services.IServices;
using Microsoft.IdentityModel.Tokens;

namespace app_bk_spotifyList.Services;

public class TokenService : ITokenService
{

    private readonly IConfiguration _config;
    private readonly IRefreshTokenService _refreshTokenService;

    public TokenService(IConfiguration config, IRefreshTokenService refreshTokenService)
    {
        _config = config;
        _refreshTokenService = refreshTokenService;
    }
    public string GenerateAccessToken(int userId, string email)
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
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["AccessTokenExpirationMinutes"]!)),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    

    public async Task<string> GenerateRefreshToken(int userId)
    {

        string refreshToken= Convert.ToBase64String(Guid.NewGuid().ToByteArray());


        var result=await _refreshTokenService.CreateRefreshToken(new CreateRefreshTokenDto
        {
            id_usuario= userId,
            refresh_token= refreshToken,
            created_at= DateTime.UtcNow,
            expires_at= DateTime.UtcNow.AddDays(7),
        });
        
        if(!result)
        {
            throw new Exception("No se pudo generar el refresh token");
        }

        return refreshToken;
    }
}
