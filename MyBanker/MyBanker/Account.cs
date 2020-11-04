using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBanker
{
    public class Account:BankAccount
    {
        private Card accountCard;

        public Card AccountCard
        {
            get { return accountCard; }
            private set { accountCard = value; }
        }

        public Account(string name,int age,ECardType cardType)
        {
            GenerateAccountNumber();
            AccountCard = CreateCard(cardType,name,age,this.AccountNumber);
            Thread.Sleep(10);
        }
    }
}
