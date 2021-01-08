using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AsymmetricServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAEncryption rsa = new RSAEncryption();
            string pvkey = rsa.pvKeyString();
            while (true)
            {
                Console.WriteLine(pvkey);
                var temp = BitConverter.GetBytes(64);
                string tempinput = Console.ReadLine();
                var tobedecrypted = Convert.FromBase64String(tempinput);

                Console.WriteLine(rsa.DecryptData(tobedecrypted));
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
