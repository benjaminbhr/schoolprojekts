using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                RequestManager fileRequest = new RequestManager(new FileRequest());
                RequestManager webRequest = new RequestManager(new Webrequest());
                Console.Clear();
                Console.WriteLine("Choose what request you want to make");
                Console.WriteLine("[1] WebRequest");
                Console.WriteLine("[2] FileRequest");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Please write the Website you want to request, (without Https. fx -> [google.com]");
                        Console.WriteLine(webRequest.MakeRequest("https://" + Console.ReadLine()));
                        ;
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine(@"Please insert the full file path fx -> 'C:\Users\Benjamin Roesdal\source'");
                        Console.WriteLine(fileRequest.MakeRequest(Console.ReadLine()));
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
