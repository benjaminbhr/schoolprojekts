using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    class Program
    {
        static void Main()
        {
            Network network = new Network();
            DNS dNS = new DNS();

            Console.WriteLine("start");
            string hostName = dNS.GetHostnameFromIp("8.8.8.8");
            Console.WriteLine(hostName);
            Console.WriteLine("slut");
            string adr = dNS.GetIpFromHostname(hostName);
            Console.WriteLine("Weee " + adr);

            string traceRoute = network.Traceroute("8.8.8.8");
            Console.WriteLine("route*** " + traceRoute);

            Console.WriteLine("DHCP Servers");
            Console.WriteLine(network.DisplayDhcpServerAddresses());

            //WIN-M69SG2Q0732.test.local
            //ZBC-RG01203MKC
            PCInfo pCInfo = new PCInfo();
            string pchostName = "DESKTOP-3CTUON6";
            Console.WriteLine("Host name : " + pchostName);
            Console.WriteLine(pCInfo.GetHostAliases(pchostName));
            Console.WriteLine(pCInfo.GetHostAddresses(pchostName));
            Console.ReadKey();
        }

    }
}
