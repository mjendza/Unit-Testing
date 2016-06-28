using NUnit.Framework;
using Training.Service.Core;

namespace Training.Service.Tests
{
    [TestFixture]
    public class EmailServiceTest
    {
        [Test]
        public void SendEmail_Success()
        {
            var sut = new EmailService();
            var response = sut.SendEmail(new EmailDTO() {Body = "a",Subject = "b",To = "matesz.jendza@gmail.com"});
            Assert.AreEqual(Response.OK.Success, response.Success);
        }
    }
}