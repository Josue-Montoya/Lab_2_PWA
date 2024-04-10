﻿using MailKit.Net.Smtp;
using MimeKit;

namespace Lab2_PWA_Juegos.Services_Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(
            string emailTo,
            string recepientName,
            string subject,
            string body)
        {
            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress(
                    _configuration["Mailtrap:EmailUsername"],
                    _configuration["Mailtrap:EmailFrom"]
                    ));

                message.To.Add(new MailboxAddress(recepientName, emailTo));

                message.Subject = subject;

                var builder = new BodyBuilder();

                var templatePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "EmailTemplates",
                    "Welcome_Email.html"
                    );

                var templateContent = File.ReadAllText(templatePath);
                templateContent = templateContent.Replace("@Name", recepientName);

                builder.HtmlBody = templateContent;

                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect(
                        _configuration["Mailtrap:Host"],
                        int.Parse(_configuration["Mailtrap:Port"]),
                        false);

                    client.Authenticate(
                        _configuration["Mailtrap:Username"],
                        _configuration["Mailtrap:Password"]
                        );

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
