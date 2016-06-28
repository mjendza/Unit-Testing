using System;
using NUnit.Framework;

namespace Training.BusinessApp.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMethod1()
        {
            throw new NullReferenceException();
        }
    }
}
