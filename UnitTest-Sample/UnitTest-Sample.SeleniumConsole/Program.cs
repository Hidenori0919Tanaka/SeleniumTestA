using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_SampleTests;

namespace UnitTest_Sample.SeleniumConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var selenium = new SeleniumTest("UnitTest-Sample");

            selenium.StartIIS();

            //IWebDriver driver = ChromeDriver;

            ChromeDriver.Navigate().GoToUrl(selenium.GetAbsoluteUrl("/Account/Login"));

            selenium.EndIIS();
        }
        //const int iisPort = 60227;
        //private Process _iisProcess;
        //private string _applicationName;

        //protected Program(string applicationName)
        //{
        //    _applicationName = applicationName;
        //}
        //public ChromeDriver ChromeDriver { get; set; }

        //private void StartIIS()
        //{
        //    _iisProcess = new Process();
        //    var applicationPath = GetApplicationPath(_applicationName);
        //    //var applicationPath = GetApplicationPath("UnitTest-Sample");
        //    var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        //    var iisPath = Path.Combine(programFiles, "IIS Express", "iisexpress.exe");
        //    var startInfo = new ProcessStartInfo
        //    {
        //        FileName = iisPath,
        //        Arguments = $"/path:\"{applicationPath}\" /port:{iisPort}",
        //    };
        //    _iisProcess = Process.Start(startInfo);
        //    //_iisProcess.StartInfo.FileName = programFiles + "\\IIS Express\\iisexpress.exe";
        //    //_iisProcess.StartInfo.Arguments = string.Format("/path:"{ 0}
        //    //" /port:{1}", applicationPath, iisPort);
        //    _iisProcess.Start();
        //}

        //protected virtual string GetApplicationPath(string applicationName)
        //{
        //    var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
        //    return Path.Combine(solutionFolder, applicationName);
        //}

        //public string GetAbsoluteUrl(string relativeUrl)
        //{
        //    if (!relativeUrl.StartsWith("/"))
        //    {
        //        relativeUrl = "/" + relativeUrl;
        //    }
        //    return String.Format("http://localhost:{0}{1}", iisPort, relativeUrl);
        //}

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    // Start IISExpress
        //    StartIIS();

        //    // Start Selenium drivers
        //    this.ChromeDriver = new ChromeDriver();
        //}

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    // Ensure IISExpress is stopped
        //    if (_iisProcess.HasExited == false)
        //    {
        //        _iisProcess.Kill();
        //    }

        //    // Stop all Selenium drivers
        //    this.ChromeDriver.Quit();
        //}
    }
}
