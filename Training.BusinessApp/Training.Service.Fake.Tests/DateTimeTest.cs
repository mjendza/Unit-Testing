using System;
using System.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training.Service.Fake.Tests
{
    [TestClass]
    public class DateTimeTest
    {
        protected DateTime NowTime = new DateTime(2016, 06, 22, 12, 14, 55);
        [TestMethod]
        public void DateTime_CheckNow_Success()
        {
            using (ShimsContext.Create())
            {
                //Even
                ShimDateTime.NowGet=()=> NowTime;
                //When
                var now = DateTime.Now;
                //Then
                Assert.AreEqual(NowTime, now);
            }
        }
    }
}
