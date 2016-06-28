using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Training.Service.Core;
using Training.Service.Tests.Fake;

namespace Training.Service.Tests
{
    [TestFixture]
    public class MockUserTest
    {
        [Test]
        public void UserService_CheckEmailCall()
        {
            //even
            var emailMock = new Mock<IEmailService>();
            emailMock.Setup(x => x.SendEmail(It.IsAny<EmailDTO>())).Returns(Response.Error);
            var sut=new UserService(emailMock.Object, new UserRepositoryFake());
            //when
            var result = sut.Save(UserObjectMother.SimpleUser());
            //then
            emailMock.Verify(x=>x.SendEmail(It.IsAny<EmailDTO>()), Times.Once);
        }
    }
}
