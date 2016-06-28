using System.Net.Mail;
using System.Text;
using Training.Service.Core;

namespace Training.Service
{
    public class EmailService : IEmailService
    {
        private SmtpClient _client;

        public EmailService()
        {
            _client = new SmtpClient();
            _client.Port = 587;
            _client.Host = "smtp.gmail.com";
            _client.EnableSsl = true;
            _client.Timeout = 10000;
            _client.DeliveryMethod = SmtpDeliveryMethod.Network;
            _client.UseDefaultCredentials = false;
            _client.Credentials = new System.Net.NetworkCredential("user@test.com", "password");
        }
        public Response SendEmail(EmailDTO message)
        {
            MailMessage mm = new MailMessage("donotreply@domain.com", message.To, message.Subject, message.Body);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //_client.Send(mm);
            return Response.OK;
        }
    }
}