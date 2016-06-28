using System;
using System.Reflection;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit2;
using Training.Service.Tests.Dummy;
using Training.Service.Tests.Fake;

namespace Training.Service.Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        private IUserService _sut;

        [TestFixtureSetUp]
        public void InitFixture()
        {
            
        }
        [SetUp]
        public void SetUp()
        {
            _sut =new UserService(new EmailServiceDummy(), new UserRepositoryFake());
        }
        [Test]
        public void SaveUser_EmptyData_ValidationFailed()
        {
            //given
            var user = new UserDTO();
            //when
            var actual = _sut.Save(user);

            //then
            Assert.AreNotEqual(0, actual);
        }
        [Test]
        //[TestCase("a@u")]
        [TestCase("abc@abs.sz")]
        public void TestMethod2(string email)
        {
           //given
            var user = UserObjectMother.SimpleUser();
            //when
            var actual = _sut.Save(user);
            //then
            Assert.IsNotNull(actual);
        }
        [Test]
        public void UseFluentBuilder_ResultIsNull()
        {
            //given
            var user = new UserFluentBuilder()
                .WithEmail("abc@abc")
                .Build();
            //when
            var actual = _sut.Save(user);
            //then
            Assert.IsNull(actual);
        }

        [Test]
        public void UseFluentBuilder_ResultIsNotNull()
        {
            //given
            var user = new UserFluentBuilder()
                .WithEmail(null)
                .Build();
            //when
            var actual = _sut.Save(user);
            //then
            Assert.IsNull(actual);
        }

        [Test]
        public void SetProjectInfo_Success()
        {
            var user = new UserDTO();
            var dynMethod = _sut.GetType().GetMethod("SetProjectInfoData",
                BindingFlags.NonPublic | BindingFlags.Instance);
            var result = dynMethod.Invoke(_sut, new object[] {user});
            var stringResult = result as string;
            Assert.NotNull(stringResult);
            Assert.True(stringResult.Contains("#;#"));
        }

        [Test]
        [AutoData]
        public void AutoCreatedData_ValidationErrorWithEmail(UserDTO user)
        {
            //given

            //when
            var result = _sut.Save(user);
            //then
            Assert.Null(result);
        }
        [Test]
        [AutoData]
        public void AutoCreatedData_Success(UserDTO user)
        {
            //given
            user.Email = "test@gmail.cio";
            //when
            var result = _sut.Save(user);
            //then
            Assert.Null(result);
        }
        [Test]
        public void GetNotExistingItem_ThrowsException()
        {
            _sut=new UserService(new EmailServiceDummy(), new UserRepositoryFake());
            Assert.Throws<InvalidOperationException>(()=>_sut.GetById(1));
        }
    }
}
