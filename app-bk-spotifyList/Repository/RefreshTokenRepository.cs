using System;
using app_bk_spotifyList.Models;
using app_bk_spotifyList.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace app_bk_spotifyList.Repository;

public class RefreshTokenRepository:IRefreshTokenRepository
{
    private readonly ApplicationDbContext _db;

    public RefreshTokenRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> CreateAsync(RefreshToken refreshToken)
    {
        await _db.RefreshTokens.AddAsync(refreshToken);
        return await SaveAsync();
    }

    public async Task<RefreshToken> GetByIdAsync(int id)
    {
        return await _db.RefreshTokens.FindAsync(id) ?? null!;
    }

    public async Task<RefreshToken> GetByTokenAsync(string token)
    {
        return await _db.RefreshTokens.FirstOrDefaultAsync(rt => rt.refresh_token == token) ?? null!;
    }

    public async Task<bool> UpdateIsActiveAsync(int id, bool isActive)
    {
        var updated = await _db.RefreshTokens
        .Where(rt => rt.id_refresh_token == id)
        .ExecuteUpdateAsync(s => s.SetProperty(rt => rt.is_active, isActive));

        return updated > 0;
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }
}
