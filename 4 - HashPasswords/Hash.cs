using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyInDotNet
{
    public class Hash
    {
        public static byte[] GenerateSalt()
        {
            const int saltLength = 32;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[saltLength];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            int tempi = 0;
            byte[] finalArray = new byte[first.Length + second.Length];
            for (int i = 0; i < first.Length; i++)
            {
                finalArray[i] = first[i];
            }

            for (int i = first.Length; i < second.Length; i++)
            {
                finalArray[i] = second[tempi];
                tempi++;
            }
            return finalArray;
        }

        public static string HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Combine(toBeHashed, salt));
                //Maybe bad?
                return Convert.ToBase64String(hash);
            }
        }
    }
}
