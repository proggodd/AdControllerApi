using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace MyAdsApi.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string to, string subject, string body)
        {
            try
            {
                var smtpServer = _configuration["Smtp:Server"];
                var smtpPort = int.Parse(_configuration["Smtp:Port"]);
                var smtpUsername = _configuration["Smtp:Username"];
                var smtpPassword = _configuration["Smtp:Password"];
                var fromAddress = new MailAddress(smtpUsername, "MyAdsApi");

                var smtp = new SmtpClient
                {
                    Host = smtpServer,
                    Port = smtpPort,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword)
                };

                using (var message = new MailMessage(fromAddress, new MailAddress(to))
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error)
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
    }
}
