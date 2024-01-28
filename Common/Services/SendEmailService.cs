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
        async public Task<UserCredential> Login() {
    
            var clientId = Environment.GetEnvironmentVariable("pocket-a3-clientId");
            var clientSecret = Environment.GetEnvironmentVariable("pocket-a3-clientsecret");
            ClientSecrets secrets = new()
            { 
            ClientId=clientId,
            ClientSecret=clientSecret,
            };
            return await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, new[] {GmailService.Scope.GmailSend },"user",CancellationToken.None);
           
           
        
        }

        async public Task SendGmail(string email, string subject, string body) {
            var credentials = await Login();
            Message emailMessage = CreateEmail("pocket.a3.app@gmail.com", email, subject,body );
            using (var gmailService = new GmailService(new BaseClientService.Initializer() { HttpClientInitializer = credentials })) {
                gmailService.Users.Messages.Send(emailMessage, "me").Execute();

            }

            
        }

        static Message CreateEmail(string from, string to, string subject, string body)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Pocket A3",from));
            mimeMessage.To.Add(new MailboxAddress(to,to));
            mimeMessage.Subject = subject;

            mimeMessage.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var stream = new MemoryStream())
            {
                mimeMessage.WriteTo(stream);
                return new Message
                {
                    Raw = Convert.ToBase64String(stream.ToArray())
                };
            }
        }
        // Helper method to base64 encode the string
        static string Base64UrlEncode(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
    }
}
