using System.Net;
using System.Runtime.InteropServices;

namespace BrowserNavigator
{
    public class Connect
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetSetCookie(string lpszUrlName, string lpszCookieName, string lpszCookieData);

        public string BrowserRequestGET(string url)
        {
            Explorer explorer = new Explorer();

            explorer.Browser.Navigate(url, null, null, null, null);

            explorer.NavigationComplete(url);

            var html = explorer.Document.documentElement.innerHTML;

            explorer.Browser.Quit();

            return html;
        }

        public string BrowserRequestGET(string url, Cookie cookie)
        {
            Explorer explorer = new Explorer();

            InternetSetCookie(url, cookie.Name, cookie.Value);

            explorer.Browser.Navigate(url, null, null, null, null);

            explorer.NavigationComplete(url);

            var html = explorer.Document.documentElement.innerHTML;

            explorer.Browser.Quit();

            return html;
        }

        public string BrowserRequestPOST(string url, byte[] form)
        {
            Explorer explorer = new Explorer();

            var postHeaders = "Content-Type: application/x-www-form-urlencoded";

            explorer.Browser.Navigate(url, null, null, form, postHeaders);

            explorer.NavigationComplete(url);

            var html = explorer.Document.documentElement.innerHTML;

            explorer.Browser.Quit();

            return html;
        }

        public string BrowserRequestPOST(string url, byte[] form, Cookie cookie)
        {
            Explorer explorer = new Explorer();

            var postHeaders = "Content-Type: application/x-www-form-urlencoded";

            InternetSetCookie(url, cookie.Name, cookie.Value);

            explorer.Browser.Navigate(url, null, null, form, postHeaders);

            explorer.NavigationComplete(url);

            var html = explorer.Document.documentElement.innerHTML;

            explorer.Browser.Quit();

            return html;
        }
    }
}