using Helperland.IServices;
using Helperland.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Helperland.Services
{
    public class EmailService : IEmailService
    {
        private string templetePath = "EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfig;

        public EmailService(IOptions<SMTPConfigModel> smtpConfigModel)
        {
            _smtpConfig = smtpConfigModel.Value;
        }

        public async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML,
                Body = GetEmailBody(userEmailOptions.Body, userEmailOptions.Replaces)
            };

            foreach (var toemail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toemail);
            }

            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.Username, _smtpConfig.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSl,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredential,
                Credentials = networkCredential
            };

            mail.BodyEncoding = System.Text.Encoding.Default;
            await smtpClient.SendMailAsync(mail);

        }

        private string GetEmailBody(string templateName, List<KeyValuePair<string, string>> replaces)
        {
            string body = File.ReadAllText(string.Format(templetePath, templateName));
            foreach (KeyValuePair<string, string> rep in replaces)
            {
                body = body.Replace(rep.Key, rep.Value);
            }
            return body;
        }

    }
}
