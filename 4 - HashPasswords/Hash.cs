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
            var ret = new byte[first.Length + second.Length];
            for (int i = 0; i < first.Length; i++)
            {
                ret[i] = first[i];
            }

            for (int i = first.Length; i < second.Length; i++)
            {
                ret[i] = second[i];
            }

            var temp = Convert.ToBase64String(ret);
            return ret;
        }

        public static string HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Combine(toBeHashed, salt));

                return Convert.ToBase64String(hash);
            }
        }
    }
}
