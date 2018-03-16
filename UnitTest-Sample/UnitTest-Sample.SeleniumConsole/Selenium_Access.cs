using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Sample.SeleniumConsole
{
    public class Selenium_Access
    {
        public void Login()
        {
            //IWebDriver driver = ChromeDriver;

            ChromeDriver.Navigate().GoToUrl(selenium.GetAbsoluteUrl("/Account/Login"));
        }
    }
}
