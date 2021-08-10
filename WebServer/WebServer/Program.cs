using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServer server = new WebServer();
            server.start(IPAddress.Parse("10.108.137.33"), 8080, 10, Directory.GetCurrentDirectory());
        }
    }
}
