using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Service.Tests
{
    
    public class UserFluentBuilder
    {
        private string email = "mail";
        public UserFluentBuilder WithEmail(string mail)
        {
            email = mail;
            return this;
        }
        public UserDTO Build()
        {
            var user = new UserDTO()
            {
                Email = email,
            };
            return user;
        }
    }
}
