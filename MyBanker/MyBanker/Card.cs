using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public abstract class Card
    {
        public string CardNumber { get;protected set; }
        public string AccountNumber { get;protected set; }
        public string RegistrationNumber { get; protected set; }
        public abstract DateTime ExpiryDate { get;protected set; }
        public string Name { get;protected set; }
        public int Age { get; protected set; }
        public int MaxWithdrawPerMonth { get;protected set; }

        protected int ChooseRandomPrefix(List<int> prefixes)
        {
            Random random = new Random();
            var r = random.Next(0, prefixes.Count()-1);
            int randomPrefix = prefixes.ElementAt(r);
            return randomPrefix;
        }

        protected virtual string GenerateCardNumber(int cardPrefix)
        {
            Random random = new Random();
            string r = "";
            r += cardPrefix;
            for (int i = 1; r.Length < 16; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }
    }
}
