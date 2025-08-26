using E_Comm.Server.Entities;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace E_Comm.Server.Services.Email
{
    public class EmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.FromName, _settings.From));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = htmlBody };
            email.Body = bodyBuilder.ToMessageBody();

            //SMTP SETTING
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.Host, _settings.Port, _settings.EnableSsl);
            await smtp.AuthenticateAsync(_settings.Username, _settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
