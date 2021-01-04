using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashingOpg
{
    public class Hash
    {
        public string ComputeMD5Hash(string tobehashed)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(tobehashed);
            using (var md5 = MD5.Create())
            {
                var hashbytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashbytes.Length; i++)
                {
                    sb.Append(hashbytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }


        public byte[] RandomNumberCrypto()
        {
            List<int> list = new List<int>();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                return data;
            }
        }
    }
}
