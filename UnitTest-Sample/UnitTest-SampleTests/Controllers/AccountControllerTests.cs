using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest_Sample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System.IO;
using UnitTest_SampleTests;

namespace UnitTest_Sample.Controllers.Tests
{
    [TestClass]
    [TestFixture]
    public class AccountControllerTests : SeleniumTest
    {
        public AccountControllerTests() : base("UnitTest-Sample") { }

        [TestMethod]
        public void LoginTest()
        {
            IndexTestByDriver(ChromeDriver);
        }

        private void IndexTestByDriver(IWebDriver driver)
        {
            // Act
            ChromeDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Account/Login")/*BaseAddress + "/Account/Login"*/);
            ChromeDriver.FindElement(By.Id("btn")).Click();

            // Assert
            NUnit.Framework.Assert.IsTrue(ChromeDriver.FindElement(By.Id("msg")).Displayed);
        }
    }
}