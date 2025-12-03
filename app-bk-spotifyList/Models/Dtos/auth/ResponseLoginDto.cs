using System;

namespace app_bk_spotifyList.Models.Dtos.auth;

public class ResponseLoginDto
{
    public UserDto user { get; set; } = null!;
    public string accessToken { get; set; } = string.Empty;

    public string refreshToken { get; set; } = string.Empty;
}
