using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = null;
            try
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver(System.IO.Directory.GetCurrentDirectory());
                driver.Navigate().GoToUrl("http://www.google.com/");

                IWebElement element = driver.FindElement(By.Id("lst-ib"));

                element.Clear();
                element.SendKeys("yahoo");

                Console.Write("Press <Enter> to exit... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                element = driver.FindElement(By.Name("btnG"));
                element.Submit();

                Console.Write("Press <Enter> to exit... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }

                driver.Quit();

            }
            catch (Exception ex)
            {
                if (driver != null)
                {
                    driver.Quit();
                }
                throw;
            }
        }
    }
}
