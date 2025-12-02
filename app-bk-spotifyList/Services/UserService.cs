using System;
using app_bk_spotifyList.Models;
using app_bk_spotifyList.Models.Dtos;
using app_bk_spotifyList.Repository.IRepository;
using app_bk_spotifyList.Services.IServices;
using AutoMapper;

namespace app_bk_spotifyList.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;

    private readonly IPasswordService _passwordService;
    

    public UserService(IUserRepository repo, IMapper mapper, IPasswordService passwordService)
    {
        _repo = repo;
        _mapper = mapper;
        _passwordService = passwordService;
    }

    public async Task<bool> CreateUserAsync(CreateUserDto createUserDto)
    {   
        if(await _repo.UserExistsByEmailAsync(createUserDto.email))
        {
            throw new Exception("El correo ya fue registrado");
        }

        var user=_mapper.Map<User>(createUserDto);
        user.created_at=DateTime.UtcNow;
        user.password=_passwordService.HashPassword(createUserDto.password);
        return await _repo.CreateUserAsync(user);
    }

    public async Task<UserDto?> GetUserAsync(int userId)
    {
        var user = await _repo.GetUserAsync(userId);

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<ICollection<User>> GetUsersAsync()
    {
        var users = await _repo.GetUsersAsync();
        return users;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user= await _repo.GetUserByEmailAsync(email);
        
        return user;
    }
}
