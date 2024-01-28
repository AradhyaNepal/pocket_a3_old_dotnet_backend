using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;
using System.Net.Mail;

namespace PocketA3.Common.Services
{
    public class SendEmailService
    {
        

        //Todo: Refactor with DI
        public UserCredential Login() {
    
            var clientId = Environment.GetEnvironmentVariable("pocket-a3-clientId");
            var clientSecret = Environment.GetEnvironmentVariable("pocket-a3-clientsecret");
            ClientSecrets secrets = new()
            { 
            ClientId=clientId,
            ClientSecret=clientSecret,
            };
            return GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, new[] {GmailService.Scope.GmailSend },"user",CancellationToken.None).Result;
           
           
        
        }

        async public Task SendGmail(string email, string subject, string message) {
            var credential= Login();

            
        }
    }
}
