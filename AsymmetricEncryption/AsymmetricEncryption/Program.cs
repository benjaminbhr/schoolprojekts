using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAEncryption rsa = new RSAEncryption();
            rsa.ToPbKey();
            while (true)
            {
                var temp = Convert.ToBase64String(rsa.EncryptData());
                Console.WriteLine(temp);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
