using System;
using NUnit.Framework;
using Training.Repository;

namespace Training.Service.Integration.Tests
{
    public class Cat
    {
        public static string Integration { get { return "IntegrationTest"; } }
    }

    
    [TestFixture]
    public class UserServiceTest
    {
        [Category("IntegrationTest")]
        [Test]
        public void TestMethod1()
        {
            var userService = new UserService(new EmailService(), new UserRepository());
            var user = userService.Save(new UserDTO() { Email = "Test@test.pl" });
        }
    }
}
