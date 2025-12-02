using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_bk_spotifyList.Models;

public class RefreshToken
{
    [Key]
    public int id_refreshToken { get; set; }

    
    public int id_usuario { get; set; }

    [Required]
    public string refresh_token { get; set; } = string.Empty;

    [Required]
    public DateTime created_at { get; set; } = DateTime.Now;

    [Required]
    public DateTime expires_at { get; set; } = DateTime.Now.AddDays(7);

    [Required]
    public bool is_active { get; set; } = true;

    [ForeignKey(nameof(id_usuario))]
    public virtual User? User { get; set; }=null!;

}
