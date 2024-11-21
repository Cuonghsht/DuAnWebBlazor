namespace DuAnWebAPI.Services.OtpEmail
{
    public interface Iemail
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
