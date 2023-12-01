using Microsoft.Extensions.Options;
using OrganikHaberlesme.Application.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Infrastructure.MessageService.EmailMessage
{
    public class EmailMessageService : IEmailMessageService
    {
        private readonly EmailMessageSettings _settings;
        public EmailMessageService(IOptions<EmailMessageSettings> settings)
        {
            _settings = settings.Value;
        }

        public void Send(string to, string message)
        {
            using SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(_settings.Mail,_settings.Password);
            client.Port = _settings.Port;
            client.Host = _settings.Host;
            client.EnableSsl = _settings.EnableSsl;

            using MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_settings.Mail);
            mailMessage.Subject = "OTP";
            mailMessage.Body = message;
            mailMessage.To.Add(to);


            client.Send(mailMessage);
        }
    }
}
