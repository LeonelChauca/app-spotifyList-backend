using System;

namespace app_bk_spotifyList.Services.IServices;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string toEmail, string subject, string body);

    Task<bool> SendVerificationEmailAsync(string toEmail, string verificationLink);

}
