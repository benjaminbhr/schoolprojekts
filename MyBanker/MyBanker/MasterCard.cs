using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class MasterCard:Card,ICreditCard
    {
        public override DateTime ExpiryDate { get;protected set; } = DateTime.Now.AddYears(4);
        public int AgeRequirement { get; set; } = 18;
        public bool HasCredit { get; set; } = true;
        public int MaxWithdrawPerDay { get; protected set; } = 5000;
        public int CreditAmount { get; set; } = 40000;
        public List<int> CardPrefix = new List<int>() { 51,52,53,54,55 };

        public MasterCard(string name, int age, string accountNumber)
        {
            if (age > AgeRequirement)
            {
                this.Age = age;
                this.Name = name;
                this.CardNumber = GenerateCardNumber(ChooseRandomPrefix(CardPrefix));
                this.AccountNumber = accountNumber;
                this.MaxWithdrawPerMonth = 30000;
                this.RegistrationNumber = "3520";
            }
            else
            {
                throw new Exception("You're not old enough bitch");
            }
        }
    }
}
