using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class Withdrawel:Card,IDebitCard
    {
        public override DateTime ExpiryDate { get; protected set; } = DateTime.MaxValue;
        public bool InternationalUse { get; set; } = true;
        public bool InternetUse { get; set; } = true;
        public int AgeRequirement { get; set; } = 0;
        public List<int> CardPrefix = new List<int>() { 2400 };


        public Withdrawel(string name, int age, string accountNumber)
        {
            if (age > AgeRequirement)
            {
                this.Age = age;
                this.Name = name;
                this.CardNumber = GenerateCardNumber(ChooseRandomPrefix(CardPrefix));
                this.AccountNumber = accountNumber;
                this.MaxWithdrawPerMonth = 50000;
                this.RegistrationNumber = "3520";
            }
            else
            {
                throw new Exception("You're not old enough. bitch");
            }
        }
    }
}
