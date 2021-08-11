using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            Console.WriteLine("Local Machine's Host Name: " + strHostName);
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

            var regex = new Regex(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

            var addr = ipEntry.AddressList.Where(e => true == regex.IsMatch(e.ToString()));
            WebServer server = new WebServer();

            server.start(addr.FirstOrDefault(), 8080, 10, Directory.GetCurrentDirectory());
        }
    }
}
