namespace BrowserNavigator
{
    public class Connect
    {
        public string BrowserRequestGET(string url)
        {
            Explorer explorer = new Explorer();

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
    }
}