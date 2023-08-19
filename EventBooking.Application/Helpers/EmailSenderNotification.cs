using EventBooking.Application.Error;
using EventBooking.Domain.CustomEntities;
using EventBooking.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace EventBooking.Application.Helpers
{
    public class EmailSenderNotification : IEmailSenderNotification
    {
        private readonly EmailSettings _settings;

        public EmailSenderNotification(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task EmailSender(string ToEmail, string Subject, string Body)
        {
            // Configure email settings
            string smtpServer = _settings.SmtpServer;
            int smtpPort = _settings.SmtpPort;
            string smtpUsername = _settings.SmtpUsername;
            string smtpPassword = _settings.SmtpPassword;
            string fromEmail = _settings.FromEmail;
            string toEmail = ToEmail;
            string subject = Subject;
            string body = Body;

            // Create an instance of SmtpClient
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true; // Use SSL for secure connection

                // Compose the email
                using MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);
                mailMessage.IsBodyHtml = true; // Set to true if using HTML in the email body

                // Send the email
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
                catch (HttpException e)
                {
                    throw new HttpException(HttpStatusCode.InternalServerError, "Something went wrong sending an email");
                }
            }
        }
    }
}
