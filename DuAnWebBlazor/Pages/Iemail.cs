﻿namespace DuAnWebBlazor.Pages
{
    public interface Iemail
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
