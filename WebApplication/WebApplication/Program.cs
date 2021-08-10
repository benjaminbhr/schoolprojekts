using System;
using System.Text.RegularExpressions;

namespace WebApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Url:");
                string requestUrl = Console.ReadLine();
                var httpresponse = HttpService.GetHttpResponse(requestUrl).Result;
                Console.WriteLine(httpresponse);
                Console.ReadLine();
            }
        }
    }
}
