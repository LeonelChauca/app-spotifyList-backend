using System;
using System.ComponentModel.DataAnnotations;

namespace app_bk_spotifyList.Models.Dtos.RefreshToken;

public class RefreshTokenDto
{

    public int id_refreshToken { get; set; }

    
    public int id_usuario { get; set; }

    
    public string refresh_token { get; set; } = string.Empty;

    
    public DateTime created_at { get; set; } = DateTime.Now;

    
    public DateTime expires_at { get; set; } = DateTime.Now.AddDays(7);
    
    public bool is_active { get; set; } = true;

    public virtual User? User { get; set; }=null!;
}
