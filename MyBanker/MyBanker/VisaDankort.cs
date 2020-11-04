using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class VisaDankort:Card,ICreditCard
    {
        public override DateTime ExpiryDate { get; protected set; } = DateTime.Now.AddYears(4);

        public int CreditAmount { get; set; } = 20000;

        public int AgeRequirement { get; set; } = 18;

        public bool HasCredit { get; set; } = true;

        public List<int> CardPrefix = new List<int>(){4};

        public VisaDankort(string name,int age,string accountNumber)
        {
            if (age > AgeRequirement)
            {
                this.Age = age;
                this.Name = name;
                this.CardNumber = GenerateCardNumber(ChooseRandomPrefix(CardPrefix));
                this.AccountNumber = accountNumber;
                this.MaxWithdrawPerMonth = 25000;
                this.RegistrationNumber = "3520";
            }
            else
            {
                throw new Exception("You're not old enough bitch");
            }
        }

    }
}
