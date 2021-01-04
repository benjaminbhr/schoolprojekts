using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberOpg
{
    class Program
    {
        static List<int> RandomNumberCrypto()
        {
            List<int> list = new List<int>();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];

                for (int i = 0; i < 100000; i++)
                {
                    rng.GetBytes(data);

                    int value = BitConverter.ToInt32(data, 0);
                    list.Add(value);
                }
            }
            return list;
        }

        static List<int> RandomNumbers()
        {
            List<int> list = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 100000; i++)
            {
                var rnd = random.Next();
                list.Add(rnd);
            }
            return list;
        }

        static void Main(string[] args)
        {
            Stopwatch cryptosw = new Stopwatch();
            cryptosw.Start();
            var randomCryptNumbers1 = RandomNumberCrypto();
            var randomCryptNumbers2 = RandomNumberCrypto();
            cryptosw.Stop();
            var randomCryptNumberTime = cryptosw.ElapsedMilliseconds;

            Stopwatch randomSw = new Stopwatch();
            randomSw.Start();
            var randomNumbers1 = RandomNumbers();
            var randomNumbers2 = RandomNumbers();
            randomSw.Stop();
            var randomNumbersTime = randomSw.ElapsedMilliseconds;

            foreach (var item in randomNumbers2)
            {
                randomNumbers1.Add(item);
            }
            foreach (var item in randomCryptNumbers2)
            {
                randomCryptNumbers1.Add(item);
            }

            List<int> randomNumbersDupes = new List<int>();
            List<int> randomCryptoNumbersDupes = new List<int>();



            if (randomCryptNumbers1.Count != randomCryptNumbers1.Distinct().Count())
            {
                foreach (var item in randomCryptNumbers1.Distinct())
                {
                    randomCryptoNumbersDupes.Add(item);
                }
            }



            if (randomNumbers1.Count != randomNumbers1.Distinct().Count())
            {
                foreach (var item in randomNumbers1.Distinct())
                {
                    randomNumbersDupes.Add(item);
                }
            }



            int listcount = randomNumbers1.Count() - randomNumbers1.Distinct().Count();
            int originalListCount = randomNumbers1.Count;
            double percent = (double)listcount / (double)originalListCount * 100;


            int cryptolistcount = randomCryptNumbers1.Count() - randomCryptNumbers1.Distinct().Count();
            int cryptooriginalListCount = randomCryptNumbers1.Count;
            double cryptopercent = (double)cryptolistcount / (double)cryptooriginalListCount * 100;


            Console.WriteLine($"The random numbers list of {randomNumbers1.Count} numbers had a dupe percentage of {percent}% and it took {randomNumbersTime}ms to generate the numbers");
            Console.WriteLine($"The random crypto numbers list of {randomCryptNumbers1.Count} numbers had a dupe percentage of {cryptopercent}% and it took {randomCryptNumberTime}ms to generate the numbers");
            Console.ReadLine();
        }
    }
}
