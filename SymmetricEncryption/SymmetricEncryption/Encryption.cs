using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryption
{
    public class Encryption
    {
        static byte[] salt = new byte[] {3,9,1,3,7,1,9,6 };

        public static byte[] Encrypt(byte[] tobeEncrypted, byte[] password,string cipher)
        {
            SymmetricAlgorithm mySymmetricAlg = null;
            byte[] encrypted = null;
            switch (cipher)
            {
                case "DES":
                    mySymmetricAlg = DES.Create();
                    mySymmetricAlg.KeySize = 64;
                    mySymmetricAlg.BlockSize = 64;
                    break;
                case "AES":
                    mySymmetricAlg = Aes.Create();
                    mySymmetricAlg.KeySize = 256;
                    mySymmetricAlg.BlockSize = 128;
                    break;
                case "TripleDES":
                    mySymmetricAlg = TripleDES.Create();
                    mySymmetricAlg.KeySize = 192;
                    mySymmetricAlg.BlockSize = 64;
                    break;
                default:
                    break;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                using (mySymmetricAlg)
                {
                    var key = new Rfc2898DeriveBytes(password, salt, 1000);
                    mySymmetricAlg.Key = key.GetBytes(mySymmetricAlg.KeySize / 8);
                    mySymmetricAlg.IV = key.GetBytes(mySymmetricAlg.BlockSize / 8);
                    mySymmetricAlg.Mode = CipherMode.CBC;

                    using (var cryptostream = new CryptoStream(ms, mySymmetricAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptostream.Write(tobeEncrypted, 0, tobeEncrypted.Length);
                        cryptostream.FlushFinalBlock();
                    }
                    encrypted = ms.ToArray();
                }
            }
            return encrypted;
        }

        public static byte[] Decrypt(byte[] tobeDecrypted, byte[] password, string cipher)
        {
            SymmetricAlgorithm mySymmetricAlg = null;
            byte[] decrypted = null;
            switch (cipher)
            {
                case "DES":
                    mySymmetricAlg = DES.Create();
                    mySymmetricAlg.KeySize = 64;
                    mySymmetricAlg.BlockSize = 64;
                    break;
                case "AES":
                    mySymmetricAlg = Aes.Create();
                    mySymmetricAlg.KeySize = 256;
                    mySymmetricAlg.BlockSize = 128;
                    break;
                case "TripleDES":
                    mySymmetricAlg = TripleDES.Create();
                    mySymmetricAlg.KeySize = 192;
                    mySymmetricAlg.BlockSize = 64;
                    break;
                default:
                    break;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                using (mySymmetricAlg)
                {
                    var key = new Rfc2898DeriveBytes(password, salt, 1000);
                    mySymmetricAlg.Key = key.GetBytes(mySymmetricAlg.KeySize / 8);
                    mySymmetricAlg.IV = key.GetBytes(mySymmetricAlg.BlockSize / 8);
                    mySymmetricAlg.Mode = CipherMode.CBC;

                    using (var cryptostream = new CryptoStream(ms, mySymmetricAlg.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptostream.Write(tobeDecrypted, 0, tobeDecrypted.Length);
                        cryptostream.FlushFinalBlock();
                    }
                    decrypted = ms.ToArray();
                }
            }
            return decrypted;
        }
    }
}
