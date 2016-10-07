using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Threading.Tasks;

namespace Karellen.Web.Identity.Servico
{
    public class EmailIdentityServico : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var apiKey = ConfigurationManager.AppSettings["sendgridapikey"];
            dynamic sg = new SendGridAPIClient(apiKey);

            var from = new Email("naoresponda@karellen.azurewebsites.net");
            var subject = message.Subject;
            var to = new Email(message.Destination);
            var content = new Content("text/html", message.Body);
            var mail = new Mail(from, subject, to, content);

            sg.client.mail.send.post(requestBody: mail.Get());

            return Task.FromResult(0);
        }
    }
}