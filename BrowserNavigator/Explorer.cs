using mshtml;
using SHDocVw;
using System;

namespace BrowserNavigator
{
    public class Explorer
    {
        public InternetExplorer Browser;
        public HTMLDocument Document;

        public Explorer()
        {
            Browser = new InternetExplorer();
            Browser.Visible = false;
            Browser.ToolBar = 0;
            Browser.MenuBar = false;
            Browser.StatusBar = false;
        }

        public void NavigationComplete(string url)
        {
            while (url.Contains(Browser.LocationName))
            {
                Console.WriteLine("Aguardando carregamento da página...");
            }

            this.Document = Browser.Document;
        }
    }
}
