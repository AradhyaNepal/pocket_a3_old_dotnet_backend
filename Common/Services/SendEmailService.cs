using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using MimeKit;
using PocketA3.Features.Auth.Model;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PocketA3.Common.Services
{
    public class SendEmailService
    {
        

        //Todo: Refactor with DI
        public void SendMail(string toMail,string subject,string body) {
            var email = "pocket.a3.app@gmail.com";
            var appPassword = Environment.GetEnvironmentVariable("pocket-a3-temp");
            MailMessage mailMessage = new MailMessage(email, toMail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            // Create a new SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(email, appPassword);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

        }

    }
}
