using System;
using app_bk_spotifyList.Models;
using app_bk_spotifyList.Models.Dtos.RefreshToken;
using AutoMapper;

namespace app_bk_spotifyList.Mapping;

public class RefreshTokenProfile:Profile
{
    public RefreshTokenProfile()
    {
        CreateMap<RefreshTokenDto, RefreshToken>().ReverseMap();
        CreateMap<CreateRefreshTokenDto, RefreshToken>().ReverseMap();
        
    }
}
