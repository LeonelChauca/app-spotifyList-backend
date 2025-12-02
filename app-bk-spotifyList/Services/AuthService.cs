using System;
using app_bk_spotifyList.Models;
using app_bk_spotifyList.Models.Dtos;
using app_bk_spotifyList.Models.Dtos.auth;
using app_bk_spotifyList.Services.IServices;
using AutoMapper;

namespace app_bk_spotifyList.Services;

public class AuthService : IAuthService
{
    public readonly IUserService _userService;
    public readonly IPasswordService _passwordService;

    public readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthService(IUserService userService, IPasswordService passwordService, ITokenService tokenService, IMapper mapper)
    {
        _userService = userService;
        _passwordService = passwordService;
        _tokenService = tokenService;   
        _mapper = mapper;
    }
    public async Task<ResponseLoginDto> login(AuthDto authDto)
    {
        var user= await _userService.GetUserByEmailAsync(authDto.email);
        if(user==null)
        {
            throw new Exception("Usuario no encontrado");
        }
        
        if(!_passwordService.VerifyPassword(authDto.password, user.password))
        {
            throw new Exception("Contraseña incorrecta");
        }
        
        var accessToken = _tokenService.GenerateAccessToken(user.id_usuario, user.email);

        var refreshToken= _tokenService.GenerateRefreshToken();

        return new ResponseLoginDto
        {
            user = _mapper.Map<UserDto>(user),
            accessToken = accessToken
        };
    }
    
    Task<bool> IAuthService.logout()
    {
        throw new NotImplementedException();
    }

    Task<bool> IAuthService.Register(UserDto userDto)
    {
        throw new NotImplementedException();
    }
}
