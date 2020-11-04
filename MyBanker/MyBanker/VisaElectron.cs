using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class VisaElectron:Card,IDebitCard
    {
        public override DateTime ExpiryDate { get;protected set; } = DateTime.Now.AddYears(4);
        public bool InternationalUse { get; set; } = true;
        public bool InternetUse { get; set; } = true;
        public int AgeRequirement { get; set; } = 15;
        public List<int> CardPrefix = new List<int>() { 4026,417500,4508,4844,4913,4917};


        public VisaElectron(string name, int age, string accountNumber)
        {
            if (age >= AgeRequirement)
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
