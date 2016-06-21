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
        }
        public Response SendEmail(EmailDTO message)
        {
            return Response.Error;
        }
    }
}