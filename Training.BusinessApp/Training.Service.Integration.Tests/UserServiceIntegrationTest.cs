using System;
using NUnit.Framework;
using Training.Repository;
using Training.Service.Tests;
using Assert = NUnit.Framework.Assert;

namespace Training.Service.Integration.Tests
{
    [TestFixture]
    public class UserServiceIntegrationTest
    {
        [Test]
        public void FullStack_Test_CRUD()
        {
            var _sut= new UserService(new EmailService(), new UserRepository());
            Assert.Throws<InvalidOperationException>(() => _sut.GetById(1050900));
            var newUser = UserObjectMother.SimpleUser();
            var createdUser=_sut.Save(newUser);
            Assert.NotNull(createdUser);
            Assert.Greater(createdUser.Id, 0);
            var selectedUser = _sut.GetById(createdUser.Id);
            Assert.NotNull(selectedUser);
            Assert.AreEqual(selectedUser.Email, createdUser.Email);
            selectedUser.Email = "newEmail@address.con";
            var updatedUser=_sut.Save(selectedUser);
            updatedUser.Email = selectedUser.Email;
        }
    }
}
