using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Service.Core;

namespace Training.Service.Tests.Dummy
{
    public class EmailServiceDummy : IEmailService 
    {
        public Response SendEmail(EmailDTO message)
        {
            return Response.OK;
        }
    }
}
