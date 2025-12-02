using System;
using System.ComponentModel.DataAnnotations;

namespace app_bk_spotifyList.Models.Dtos;

public class CreateUserDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string name { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    public string lastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email no es válido")]
    public string email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string password { get; set; } = string.Empty;
}
