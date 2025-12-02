using System;

namespace app_bk_spotifyList.Models.Dtos;

public class UserDto
{
    public int id_usuario { get; set; }

    public string name { get; set; }= string.Empty;

    public string lastName { get; set; }= string.Empty;

    public string email { get; set; }= string.Empty;

    public bool is_active { get; set; }

}
