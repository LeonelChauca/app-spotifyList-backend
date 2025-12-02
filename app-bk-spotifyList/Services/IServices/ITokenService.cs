using System;

namespace app_bk_spotifyList.Services.IServices;

public interface ITokenService
{

    public string GenerateRefreshToken();

    public string GenerateAccessToken(int userId, string email);

}
