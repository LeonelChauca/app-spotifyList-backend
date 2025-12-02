using System;
using app_bk_spotifyList.Models;
using app_bk_spotifyList.Models.Dtos;
using AutoMapper;

namespace app_bk_spotifyList.Mapping;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<User,CreateUserDto>().ReverseMap();
    }
}
