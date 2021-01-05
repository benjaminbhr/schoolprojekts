using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rfc2898Opg
{
    class Program
    {
        static byte[] tempArray = Convert.FromBase64String("VOVvvQT/TzLl3HYoMMQzPw1t8Z0/REEF2CZPvOTHiYs=");
        static int HashingIterationsCount = 10;
        static byte[] ComputeHash(string password,byte[] salt,int iterations,int hashByteSize)
        {
            using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt))
            {
                hashGenerator.IterationCount = iterations;

                return hashGenerator.GetBytes(hashByteSize);
            }
        }

        public static byte[] GenerateSalt()
        {
            const int saltLength = 32;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltLength];
                randomNumberGenerator.GetBytes(randomNumber);

                using (StreamWriter outputFile = new StreamWriter(@"C:\Users\Benjamin\source\repos\Rfc2898Opg\Rfc2898Opg\Salt.txt"))
                {
                    outputFile.Write(Convert.ToBase64String(randomNumber));
                }
                return randomNumber;
            }
        }


        public static void VerifyPassword(string password)
        {
            string salt = System.IO.File.ReadAllText(@"C:\Users\Benjamin\source\repos\Rfc2898Opg\Rfc2898Opg\Salt.txt");
            string hashedPW = System.IO.File.ReadAllText(@"C:\Users\Benjamin\source\repos\Rfc2898Opg\Rfc2898Opg\HashedPW.txt");
            var temp = ComputeHash(password, Convert.FromBase64String(salt), HashingIterationsCount, 128);
            string pwString = Convert.ToBase64String(temp);
            if (pwString == hashedPW)
            {
                Console.WriteLine("You have successfully entered the correct password!");
            }
            else
            {
                Console.WriteLine("That was not the correct password!");
            }
            Console.WriteLine("This is the 2nd entered password hashed " + pwString);
        }

        static void Main(string[] args)
        {
            var temp = ComputeHash(Console.ReadLine(), GenerateSalt(), HashingIterationsCount, 128);
            using (StreamWriter outputFile = new StreamWriter(@"C:\Users\Benjamin\source\repos\Rfc2898Opg\Rfc2898Opg\HashedPW.txt"))
            {
                outputFile.Write(Convert.ToBase64String(temp));
                Console.WriteLine("This is the HashedPW saved to file " + Convert.ToBase64String(temp));
            }


            VerifyPassword(Console.ReadLine());

            Console.ReadLine();
        }
    }
}
