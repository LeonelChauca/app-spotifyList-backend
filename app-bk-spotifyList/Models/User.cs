using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace app_bk_spotifyList.Models;

[Index(nameof(email), IsUnique = true)]
public class User
{
    [Key]
    public int id_usuario { get; set; }

    [Required]
    public string name { get; set; } = string.Empty;

    [Required]
    public string lastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string email { get; set; } = string.Empty;

    [Required]
    public string password { get; set; } = string.Empty;

    [Required]
    public bool is_active { get; set; } = true;

    [Required]
    public DateTime created_at { get; set; } = DateTime.Now;

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
