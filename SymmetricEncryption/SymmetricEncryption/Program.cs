using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryption
{
    class Program
    {
        static string password = "orion123";
        static byte[] pwInBytes = System.Text.Encoding.UTF8.GetBytes(password);
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What do you want to encrypt?");
                Console.WriteLine("[1] Files");
                Console.WriteLine("[2] Plain Text");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("What algorithm do you want to use?");
                        Console.WriteLine("[1] AES");
                        Console.WriteLine("[2] DES");
                        Console.WriteLine("[3] TripleDES");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                                Console.Clear();
                                FileEncryption.EncryptFiles("AES");
                                Console.WriteLine("These files have been encrypted using AES Algorithm!");
                                Console.WriteLine("Press 'Enter' to decrypt these files again using AES Algorithm");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Enter:
                                        Console.Clear();
                                        FileEncryption.DecryptFiles("AES");
                                        Console.WriteLine("These files have been decrypted using AES Algorithm");
                                        Console.WriteLine("Press 'Enter' to return to main menu");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case ConsoleKey.D2:
                                Console.Clear();
                                FileEncryption.EncryptFiles("DES");
                                Console.WriteLine("These files have been encrypted using DES Algorithm!");
                                Console.WriteLine("Press 'Enter' to decrypt these files again using DES Algorithm");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Enter:
                                        Console.Clear();
                                        FileEncryption.DecryptFiles("DES");
                                        Console.WriteLine("These files have been decrypted using DES Algorithm");
                                        Console.WriteLine("Press 'Enter' to return to main menu");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case ConsoleKey.D3:
                                Console.Clear();
                                FileEncryption.EncryptFiles("TripleDES");
                                Console.WriteLine("These files have been encrypted using TripleDES Algorithm!");
                                Console.WriteLine("Press 'Enter' to decrypt these files again using TripleDES Algorithm");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Enter:
                                        Console.Clear();
                                        FileEncryption.DecryptFiles("TripleDES");
                                        Console.WriteLine("These files have been decrypted using TripleDES Algorithm");
                                        Console.WriteLine("Press 'Enter' to return to main menu");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("What algorithm do you want to use?");
                        Console.WriteLine("[1] AES");
                        Console.WriteLine("[2] DES");
                        Console.WriteLine("[3] TripleDES");
                        byte[] tempbytearray = null;
                        byte[] encryptedBytes = null;
                        byte[] decryptedBytes = null;
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                                Console.Clear();
                                Console.WriteLine("Please write the message you want encrypt!");
                                string tempmsg = Console.ReadLine();
                                tempbytearray = System.Text.Encoding.UTF8.GetBytes(tempmsg);
                                encryptedBytes = Encryption.Encrypt(tempbytearray, pwInBytes, "AES");
                                Console.WriteLine("Encrypted message - " + System.Text.Encoding.UTF8.GetString(encryptedBytes));
                                Console.WriteLine("Press 'enter' to decrypt this message");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Enter:
                                        decryptedBytes = Encryption.Decrypt(encryptedBytes, pwInBytes, "AES");
                                        Console.WriteLine("Decrypted message - " + System.Text.Encoding.UTF8.GetString(decryptedBytes));
                                        Console.WriteLine("Press 'Enter' to return to main menu");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case ConsoleKey.D2:
                                Console.Clear();
                                Console.WriteLine("Please write the message you want encrypt!");
                                string tempmsg2 = Console.ReadLine();
                                tempbytearray = System.Text.Encoding.UTF8.GetBytes(tempmsg2);
                                encryptedBytes = Encryption.Encrypt(tempbytearray, pwInBytes, "AES");
                                Console.WriteLine("Encrypted message - " + System.Text.Encoding.UTF8.GetString(encryptedBytes));
                                Console.WriteLine("Press 'enter' to decrypt this message");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Enter:
                                        decryptedBytes = Encryption.Decrypt(encryptedBytes, pwInBytes, "AES");
                                        Console.WriteLine("Decrypted message - " + System.Text.Encoding.UTF8.GetString(decryptedBytes));
                                        Console.WriteLine("Press 'Enter' to return to main menu");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case ConsoleKey.D3:
                                Console.Clear();
                                Console.WriteLine("Please write the message you want encrypt!");
                                string tempmsg3 = Console.ReadLine();
                                tempbytearray = System.Text.Encoding.UTF8.GetBytes(tempmsg3);
                                encryptedBytes = Encryption.Encrypt(tempbytearray, pwInBytes, "AES");
                                Console.WriteLine("Encrypted message - " + System.Text.Encoding.UTF8.GetString(encryptedBytes));
                                Console.WriteLine("Press 'enter' to decrypt this message");
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Enter:
                                        decryptedBytes = Encryption.Decrypt(encryptedBytes, pwInBytes, "AES");
                                        Console.WriteLine("Decrypted message - " + System.Text.Encoding.UTF8.GetString(decryptedBytes));
                                        Console.WriteLine("Press 'Enter' to return to main menu");
                                        Console.ReadLine();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}
