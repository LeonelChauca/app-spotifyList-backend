using System;
using app_bk_spotifyList.Models.Dtos.RefreshToken;

namespace app_bk_spotifyList.Services.IServices;

public interface IRefreshTokenService
{   

    public Task<bool> CreateRefreshToken(CreateRefreshTokenDto createRefreshTokenDto);

    public Task<bool> InvalidateRefreshToken(string token);

    public Task<string> GetRefreshToken(int id);
}
