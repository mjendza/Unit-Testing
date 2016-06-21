using Training.Service.Core;

namespace Training.Service
{
    public interface IEmailService
    {
        Response SendEmail(EmailDTO message);
    }
}