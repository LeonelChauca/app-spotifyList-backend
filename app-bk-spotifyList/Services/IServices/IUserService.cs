using System;
using app_bk_spotifyList.Models;
using app_bk_spotifyList.Models.Dtos;

namespace app_bk_spotifyList.Services.IServices;

public interface IUserService
{
    Task<bool> CreateUserAsync(CreateUserDto createUserDto);

    Task<UserDto?> GetUserAsync(int userId);

    Task<ICollection<User>> GetUsersAsync();

    Task<User?> GetUserByEmailAsync(string email);
    
}
