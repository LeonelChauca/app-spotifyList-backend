using System;
using app_bk_spotifyList.Models;
using app_bk_spotifyList.Models.Dtos;
using app_bk_spotifyList.Models.Dtos.auth;

namespace app_bk_spotifyList.Services.IServices;

public interface IAuthService
{
    public Task<ResponseLoginDto> login (AuthDto authDto);

    public Task<bool> Register (UserDto userDto);

    public Task<bool> logout ();
}
