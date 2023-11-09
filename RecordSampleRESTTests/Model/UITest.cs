using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RecordSampleRESTTests.Model
{
    [TestClass]
    public class UITest
    {
        private static readonly string DriverDirectory = "C:\\Web Drivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            //_driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/ohsab/Desktop/Datamatiker/3.%20Semester/Programmering/JavaScript/MusicRecords/index.html");
            string Title = _driver.Title;
            Assert.AreEqual("Music Records", Title);
        }

    }
}
