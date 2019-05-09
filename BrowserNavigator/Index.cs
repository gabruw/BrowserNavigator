using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Navegator
{
    public class Index
    {
        static void Main(string[] args)
        {
            var driverService = InternetExplorerDriverService.CreateDefaultService();
            driverService.LibraryExtractionPath = Environment.CurrentDirectory;

            var options = new InternetExplorerOptions();
            options.EnableNativeEvents = true;
            options.IgnoreZoomLevel = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            IWebDriver ieDriver = new InternetExplorerDriver(driverService, options, TimeSpan.FromSeconds(180));
            ieDriver.Navigate().GoToUrl("http://accounts.atp.com/Login/Login?spId=aviationHub");

            var html = ieDriver.PageSource;

            ieDriver.Quit();
        }
    }
}