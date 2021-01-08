using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricEncryption
{
    class RSAEncryption
    {
        static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(1024);


        public byte[] EncryptData()
        {
            var plainText = Console.ReadLine();
            byte[] bytesplaintText = System.Text.Encoding.UTF8.GetBytes(plainText);
            byte[] bytesCypherText = csp.Encrypt(bytesplaintText, false);
            string cyphertext = Encoding.UTF8.GetString(bytesCypherText);
            return bytesCypherText;
        }

        public RSAParameters ToPbKey()
        {
            string tempstring = System.IO.File.ReadAllText(@"C:\Users\Benjamin\source\repos\AsymmetricEncryption\AsymmetricServer\PbKey.txt");
            var sr = new System.IO.StringReader(tempstring);
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            RSAParameters pubKey = (RSAParameters)xs.Deserialize(sr);
            csp.FromXmlString(tempstring);
            return pubKey;
        }
    }
}
