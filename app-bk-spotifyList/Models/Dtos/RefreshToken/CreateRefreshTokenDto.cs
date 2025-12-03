using System;
using System.ComponentModel.DataAnnotations;

namespace app_bk_spotifyList.Models.Dtos.RefreshToken;

public class CreateRefreshTokenDto
{

    [Required(ErrorMessage = "El ID de usuario es obligatorio")]
    public int id_usuario { get; set; }

    [Required(ErrorMessage = "El token de refresco es obligatorio")]
    public string refresh_token { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de creación es obligatoria")]
    public DateTime created_at { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "La fecha de expiración es obligatoria")]
    public DateTime expires_at { get; set; } = DateTime.Now.AddDays(7);
}
