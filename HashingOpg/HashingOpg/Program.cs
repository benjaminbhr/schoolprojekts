using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashingOpg
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = System.Text.Encoding.ASCII.GetBytes(Console.ReadLine());
            Hash hash = new Hash();
            var testing = hash.HashHMAC(hash.RandomNumberCrypto(),message);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < testing.Length; i++)
            {
                sb.Append(testing[i].ToString("X2"));
            }
            Console.WriteLine(sb);
            Console.ReadLine();
        }
    }
}
