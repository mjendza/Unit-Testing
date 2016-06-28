using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Service.Tests
{
    public static  class UserObjectMother
    {
        public static UserDTO SimpleUser()
        {
            var user = new UserDTO();
            user.Email = "test@gmail.com";
            user.Modified=DateTime.Now;
            user.Login = "Test";
            return user;
        }
    }
}
