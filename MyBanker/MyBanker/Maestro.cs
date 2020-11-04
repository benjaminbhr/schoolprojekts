using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class Maestro:Card,IDebitCard
    {
        public override DateTime ExpiryDate { get; protected set; } = DateTime.Now.AddYears(5).AddMonths(8);
        public bool InternationalUse { get; set; } = true;
        public bool InternetUse { get; set; } = true;
        public int AgeRequirement { get; set; } = 18;
        public List<int> CardPrefix = new List<int>() { 5018,5020,5038,5893,6304,6759,6761,6762,6763 };


        public Maestro(string name, int age, string accountNumber)
        {
            if (age >= AgeRequirement)
            {
                this.Age = age;
                this.Name = name;
                this.CardNumber = GenerateCardNumber(ChooseRandomPrefix(CardPrefix));
                this.AccountNumber = accountNumber;
                this.MaxWithdrawPerMonth = 20000;
                this.RegistrationNumber = "3520";
            }
            else
            {
                throw new Exception("You're not old enough bitch");
            }
        }
    }
}
