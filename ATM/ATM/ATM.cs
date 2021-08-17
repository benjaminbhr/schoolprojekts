using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATM
    {
        public string Withdraw(CreditCard card,string pincode,double amount)
        {
            var result = card.Withdraw(pincode,amount);
            return result;
        }

        public string Deposit(CreditCard card, string pincode, double amount)
        {
            var result = card.Deposit(pincode, amount);
            return result;
        }

        public double ShowAmount(CreditCard card, string pincode)
        {
            return card.BankAccount.AvailableAmount;
        }
    }
}
