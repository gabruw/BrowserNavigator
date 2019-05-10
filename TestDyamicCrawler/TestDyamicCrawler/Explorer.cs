using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDyamicCrawler
{
    public class Explorer
    {
        private InternetExplorer explorer;
        private HTMLDocument document;

        public delegate void NavigateCompleteEventHandler(HTMLDocument document, string url);
        public event NavigateCompleteEventHandler NavigateCompleteEvent;

        public Explorer()
        {
            explorer = new InternetExplorer();
            explorer.Visible = true;
            explorer.ToolBar = 0;
            explorer.MenuBar = false;
            explorer.StatusBar = false;

            explorer.NavigateComplete2 += new DWebBrowserEvents2_NavigateComplete2EventHandler(explorer_NavigateComplete2);
        }

        private void explorer_NavigateComplete2(object pDisp, ref object URL)
        {
            this.document = (HTMLDocument)explorer.Document;
            NavigateCompleteEvent((HTMLDocument)this.document, URL.ToString());
        }

        public void Navigate(string url)
        {
            object empty = string.Empty;
            explorer.Navigate(url, ref empty, ref empty, ref empty, ref empty);
        }

        public HTMLDocument Document
        {
            get
            {
                if (document == null)
                {
                    return null;
                }

                return document;
            }
        } 
    }
}