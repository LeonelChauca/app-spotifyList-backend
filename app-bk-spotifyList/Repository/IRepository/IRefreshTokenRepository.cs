using System;
using app_bk_spotifyList.Migrations;
using app_bk_spotifyList.Models;

namespace app_bk_spotifyList.Repository.IRepository;

public interface IRefreshTokenRepository
{

    Task<RefreshToken> GetByIdAsync(int id);
    Task<RefreshToken> GetByTokenAsync(string token);
    Task<bool> CreateAsync(RefreshToken refreshToken);
    Task<bool> UpdateIsActiveAsync(int id, bool isActive);
    Task<bool> SaveAsync();
    
}
