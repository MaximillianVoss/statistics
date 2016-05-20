using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics.Classes;
using System;

namespace Statistics.Tests
{
    [TestClass]
    public class DateConvertTest
    {
        [TestMethod]
        public void ConvertTest()
        {
            //"yyyy-MM-dd"
            Assert.AreEqual(new DateTime(2011,2,2,7,0,0),ConvertDate.ConvertDayTime("2011-02-02 07:00"));
        }
        [TestMethod]
        public void ConvertStrings()
        {
            //01.03.2016 0:00:00 06:00
            Assert.AreEqual("2016-03-01 06:00:00",ConvertDate.FormatConvert("01.03.2016 06:00", "yyyy-MM-dd hh:mm:ss"));
        }
        
    }
}