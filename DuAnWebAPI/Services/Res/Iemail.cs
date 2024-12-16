namespace DuAnWebAPI.Services.Res
{
    public interface Iemail
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
