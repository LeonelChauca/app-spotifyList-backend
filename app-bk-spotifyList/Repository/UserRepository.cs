using System;
using app_bk_spotifyList.Models;
using app_bk_spotifyList.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace app_bk_spotifyList.Repository;

public class UserRepository : IUserRepository
{

    private readonly ApplicationDbContext _db;
    
    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }    
     public async Task<bool> CreateUserAsync(User user)
    {
        await _db.Users.AddAsync(user);
        return await SaveAsync();
    }

    public async Task<User?> GetUserAsync(int userId)
    {
        return await _db.Users
                        .FirstOrDefaultAsync(u => u.id_usuario == userId);
    }

    public async Task<ICollection<User>> GetUsersAsync()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<bool> UserExistsAsync(int userId)
    {
        return await _db.Users.AnyAsync(u => u.id_usuario == userId);
    }

    public async Task<bool> UserExistsByEmailAsync(string email)
    {
        return await _db.Users.AnyAsync(u => u.email.ToLower().Trim() == email.ToLower().Trim());
    }

    public async Task<bool> SaveAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _db.Users
                        .FirstOrDefaultAsync(u => u.email.ToLower().Trim() == email.ToLower().Trim());
    }
}
