using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest_Sample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTest_SampleTests;
using OpenQA.Selenium;

namespace UnitTest_Sample.Controllers.Tests
{
    [TestClass()]
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
            ChromeDriver.Navigate().GoToUrl(GetAbsoluteUrl("/Account/Login"));
            //Pathチェック
            NUnit.Framework.Assert.AreEqual(GetAbsoluteUrl("/Account/Login"), driver.Url.ToString());
            //titleチェック
            NUnit.Framework.Assert.AreEqual("", driver.Title.ToString());
            //h2タグテキストチェック
            NUnit.Framework.Assert.AreEqual("ログイン", driver.FindElements(By.Id("SeleniumH2")).FirstOrDefault().Text.ToString());
            //userLabelチェック
            NUnit.Framework.Assert.AreEqual("ユーザー名",driver.FindElements(By.Id("SeleniumUserLabel")).FirstOrDefault().Text.ToString());
            //passwordLabelチェック
            NUnit.Framework.Assert.AreEqual("パスワード", driver.FindElements(By.Id("SeleniumPasswordLabel")).FirstOrDefault().Text.ToString());
            //buttonValueチェック
            NUnit.Framework.Assert.AreEqual("ログイン", driver.FindElement(By.Id("SeleniumLoginBtn")).GetAttribute("value").ToString());

            //login nullパターン
            var element = driver.FindElement(By.Id("SeleniumUserText"));
            element.Clear();
            element.SendKeys("");
            element = driver.FindElement(By.Id("SeleniumPasswordText"));
            element.Clear();
            element.SendKeys("");
            element = driver.FindElement(By.Id("SeleniumLoginBtn"));
            element.Click();
            NUnit.Framework.Assert.AreEqual("", driver.FindElement(By.Id("SeleniumValidationError")).Text);
            NUnit.Framework.Assert.AreEqual("ユーザ名を入力してください", driver.FindElement(By.Id("SeleniumUserError")).Text);
            NUnit.Framework.Assert.AreEqual("パスワードを入力してください", driver.FindElement(By.Id("SeleniumPasswordError")).Text);

            //login Falseパターン
            element = driver.FindElement(By.Id("SeleniumUserText"));
            element.Clear();
            element.SendKeys("aaaa");
            element = driver.FindElement(By.Id("SeleniumPasswordText"));
            element.Clear();
            element.SendKeys("aaaa");
            element = driver.FindElement(By.Id("SeleniumLoginBtn"));
            element.Click();
            NUnit.Framework.Assert.AreEqual("無効なログイン試行です。", driver.FindElement(By.Id("SeleniumValidationError")).Text);

            //login successパターン
            element = driver.FindElement(By.Id("SeleniumUserText"));
            element.Clear();
            element.SendKeys("admin");
            element = driver.FindElement(By.Id("SeleniumPasswordText"));
            element.Clear();
            element.SendKeys("admin");
            element = driver.FindElement(By.Id("SeleniumLoginBtn"));
            element.Click();
            NUnit.Framework.Assert.AreEqual(GetAbsoluteUrl(""), driver.Url.ToString());
        }
    }
}