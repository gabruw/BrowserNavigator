using System;

namespace BrowserNavigator
{
    public class Index
    {
        static void Main(string[] args)
        {
            Connect newConnect = new Connect();

            var url = "http://www.google.com.br";
            newConnect.BrowserRequestGET(url);

            Console.ReadKey();
        }
    }
}