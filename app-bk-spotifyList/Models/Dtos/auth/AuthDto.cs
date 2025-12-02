using System;
using System.ComponentModel.DataAnnotations;

namespace app_bk_spotifyList.Models.Dtos.auth;

public class AuthDto
{
    [Required(ErrorMessage ="El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email debe ser válido")]
    
    public string email { get; set; }= string.Empty;

    [Required(ErrorMessage ="La contraseña es obligatoria")]
    public string password { get; set; }= string.Empty;

}
