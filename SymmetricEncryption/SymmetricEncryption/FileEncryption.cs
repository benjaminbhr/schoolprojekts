using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryption
{
    public class FileEncryption
    {
        static string password = "orion123";
        static byte[] pwInBytes = System.Text.Encoding.UTF8.GetBytes(password);
        
        public static void EncryptFiles(string cipher)
        {
            string[] files = Directory.GetFiles(@"C:\Users\Benjamin\source\repos\EncryptionTesting", "*", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
                EncryptFile(files[i], cipher);
            }
        }

        public static void DecryptFiles(string cipher)
        {
            string[] files = Directory.GetFiles(@"C:\Users\Benjamin\source\repos\EncryptionTesting", "*", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
                DecryptFile(files[i], cipher);
            }
        }


        public static void EncryptFile(string file, string cipher)
        {

            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = Encryption.Encrypt(bytesToBeEncrypted, passwordBytes, cipher);

            File.WriteAllBytes(file, bytesEncrypted);
        }

        public static void DecryptFile(string file, string cipher)
        {

            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = Encryption.Decrypt(bytesToBeEncrypted, passwordBytes, cipher);

            File.WriteAllBytes(file, bytesDecrypted);
        }

    }
}
