using BrowserNavigator;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Navegator
{
    public class Index
    {
        static void Main()
        {
            
        }

        public void RequestGET()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var html = string.Empty;
            
            var webRequest = (HttpWebRequest)WebRequest.Create("http://accounts.atp.com/Login/Login?spId=aviationHub");


            webRequest.Method = "GET";
            webRequest.AllowAutoRedirect = true;

            var webResponse = (HttpWebResponse)webRequest.GetResponse();

            html = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF7).ReadToEnd();
        }

        public void tentativaSelenium()
        {
            const string URL = "http://accounts.atp.com/Login/Login?spId=aviationHub";

            var driverService = InternetExplorerDriverService.CreateDefaultService();
            driverService.LibraryExtractionPath = Environment.CurrentDirectory;

            var options = new InternetExplorerOptions();
            options.InitialBrowserUrl = URL;
            options.EnableNativeEvents = true;
            options.IgnoreZoomLevel = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            IWebDriver ieDriver = new InternetExplorerDriver(driverService, options, TimeSpan.FromSeconds(180));
            ieDriver.Navigate();

            var html = ieDriver.PageSource;

            ieDriver.Quit();
        }

        public void tentaivaScrapySharp()
        {

            ScrapingBrowser Browser = new ScrapingBrowser();
            WebPage PageResult = Browser.NavigateToPage(new Uri("http://accounts.atp.com/Login/Login?spId=aviationHub"));
            HtmlNode rawHTML = PageResult.Html;
        }

        public void tentativaWebClient()
        {
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            string downloadString = client.DownloadString("http://www.google.com.br");
        }
    }
}