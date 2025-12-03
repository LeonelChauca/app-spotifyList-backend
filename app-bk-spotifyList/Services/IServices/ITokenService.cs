using System;

namespace app_bk_spotifyList.Services.IServices;

public interface ITokenService
{

    public Task<string> GenerateRefreshToken(int userId);

    public string GenerateAccessToken(int userId, string email);

}
