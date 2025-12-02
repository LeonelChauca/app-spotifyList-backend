using System;
using app_bk_spotifyList.Models;

namespace app_bk_spotifyList.Repository.IRepository;

public interface IUserRepository
{
    Task<bool> CreateUserAsync(User user);
    Task<User?> GetUserAsync(int userId);
    Task<bool> UserExistsByEmailAsync(string email);
    Task<ICollection<User>> GetUsersAsync();
    Task<bool> UserExistsAsync(int userId);
    Task<bool> SaveAsync();
    Task<User?> GetUserByEmailAsync(string email);
}

