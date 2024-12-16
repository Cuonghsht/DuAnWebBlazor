namespace DuAnWebData.ConFig
{
    public interface Iemail
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
