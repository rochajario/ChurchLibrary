using ChurchLibrary.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;

namespace ChurchLibrary.Infrastructure.Services
{
    public class EmailSenderService(IOptions<EmailCredentials> options) : IEmailSender
    {
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            // Certifique-se de que as credenciais estão preenchidas
            if (string.IsNullOrEmpty(options.Value.SmtpUser) || string.IsNullOrEmpty(options.Value.SmtpPassword))
            {
                // Trate o erro, talvez com um log ou exceção
                throw new InvalidOperationException("As credenciais de e-mail não foram configuradas.");
            }

            using var client = new SmtpClient(options.Value.SmtpHost, options.Value.SmtpPort);
            client.Credentials = new NetworkCredential(options.Value.SmtpUser, options.Value.SmtpPassword);
            client.EnableSsl = true; // Use SSL para segurança

            var mailMessage = new MailMessage
            {
                From = new MailAddress(options.Value.FromEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true // Assume que o corpo é HTML
            };
            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}