using System;

namespace app_bk_spotifyList.Services.IServices;

public interface IPasswordService
{
    public string HashPassword(string password);
    
    public bool VerifyPassword(string password, string hashedPassword);
}
