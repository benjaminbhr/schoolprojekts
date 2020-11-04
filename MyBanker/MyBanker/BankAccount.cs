using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public abstract class BankAccount
    {
        private string accountNumber;

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public void GenerateAccountNumber()
        {
            string accountNumber = "";
            Random random = new Random();
            for (int i = 1; accountNumber.Length < 14; i++)
            {
                accountNumber += random.Next(0, 9).ToString();
            }
            this.AccountNumber = accountNumber;
        }

        public Card CreateCard(ECardType cardType, string name, int age, string accountNumber)
        {
            switch (cardType)
            {
                case ECardType.VisaDankort:
                    Card visacard = new VisaDankort(name, age, accountNumber);
                    return visacard;
                    break;
                case ECardType.MasterCard:
                    Card mastercard = new MasterCard(name,age,accountNumber);
                    return mastercard;
                    break;
                case ECardType.VisaElectron:
                    Card viseElectron = new VisaElectron(name,age,accountNumber);
                    return viseElectron;
                    break;
                case ECardType.Maestro:
                    Card maestro = new Maestro(name, age, accountNumber);
                    return maestro;
                    break;
                case ECardType.WithdrawelCard:
                    Card withdrawel = new Withdrawel(name, age, accountNumber);
                    return withdrawel;
                    break;
                default:
                    break;
            }

            return null;
        }
    }
}
