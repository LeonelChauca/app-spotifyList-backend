using app_bk_spotifyList.Services.IServices;

namespace app_bk_spotifyList.Services;

public class PasswordService:IPasswordService
{
    public string HashPassword(string password)
    {
        try
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al hashear la contraseña: " + ex.Message);
        }
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al verificar la contraseña: " + ex.Message);
        }
    }


}
