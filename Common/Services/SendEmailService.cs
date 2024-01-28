using System.Net;
using System.Net.Mail;

namespace PocketA3.Common.Services
{
    public class SendEmailService
    {

        public Task SendEmailAsync(string email,string subject,string message) {
            var mail = "pocket.a3.app@gmail.com";
            var password = Environment.GetEnvironmentVariable("pocket.a3");
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl=true,
                Credentials=  new NetworkCredential(mail,password)
            };
            return client.SendMailAsync(
                new MailMessage(from:mail,to:email,subject,message)
                );
        }
    }
}
