using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricServer
{
    public class RSAEncryption
    {
        public static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(1024);
        RSAParameters pvKey = csp.ExportParameters(true);
        RSAParameters pbKey = csp.ExportParameters(false);



        public string DecryptData(byte[] encryptedData)
        {

            string cyphertext = Encoding.UTF8.GetString(encryptedData);
            Console.WriteLine(cyphertext);
            byte[] bytesPlainText = csp.Decrypt(encryptedData, false);
            string plaintext = System.Text.Encoding.UTF8.GetString(bytesPlainText);
            return plaintext;
        }

        public string pbKeyString()
        {
            var sw = new System.IO.StringWriter();
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, pbKey);
            string pbKeyString = sw.ToString();
            System.IO.File.WriteAllText(@"C:\Users\Benjamin\source\repos\AsymmetricEncryption\AsymmetricServer\PbKey.txt", pbKeyString);
            return pbKeyString;
        }

        public string pvKeyString()
        {
            var sw = new System.IO.StringWriter();
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, pvKey);
            string pvKeyString = sw.ToString();
            System.IO.File.WriteAllText(@"C:\Users\Benjamin\source\repos\AsymmetricEncryption\AsymmetricServer\PvKey.txt", pvKeyString);
            return pvKeyString;
        }
    }
}
