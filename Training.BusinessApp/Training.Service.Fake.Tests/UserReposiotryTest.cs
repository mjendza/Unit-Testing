using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.DataAccess;
using Training.Repository.Fakes;
using Training.Service.Fakes;

namespace Training.Service.Fake.Tests
{
    [TestClass]
    public class UserReposiotryTest
    {
        [TestMethod]
        public void TestWithStubRepository()
        {
            var repo=new StubIUserRepository()
            {
                GetByIdInt32 = id=> { return new User(); },
            };
            
            var email = new StubEmailService();
            var sut = new UserService(email, repo);
            var result = sut.GetById(1);
            Assert.IsNotNull(result);
        }
    }
}
