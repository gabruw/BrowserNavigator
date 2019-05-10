using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDyamicCrawler
{
    class Index
    {
        static void Main(string[] args)
        {
            Index newIndex = new Index();

            var url = "http://www.google.com.br";
            newIndex.BrowserRequestGET(url);

            Console.ReadKey();
        }

        public string BrowserRequestGET(string url)
        {
            Explorer explorer = new Explorer();

            var html = string.Empty;

            explorer.NavigateCompleteEvent += new Explorer.NavigateCompleteEventHandler(GetHtml);

            explorer.Navigate(url);

            return html;
        }

        static void GetHtml(HTMLDocument document, string url)
        {
            var html = document.documentElement.innerHTML;
        }
    }
}