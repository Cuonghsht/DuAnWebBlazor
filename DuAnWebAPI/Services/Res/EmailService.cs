﻿using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Microsoft.Extensions.Options;
using DuAnWebData.Model;
using DuAnWebAPI.Services.OtpEmail;
using DuAnWebData.ConFig;
using DuAnWebAPI.Services.Res;

public class EmailService : DuAnWebAPI.Services.Res.Iemail
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(string recipientEmail, string subject, string message)
    {
        
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
        email.To.Add(new MailboxAddress("", recipientEmail));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = message };

        
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_emailSettings.SMTPServer, _emailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
