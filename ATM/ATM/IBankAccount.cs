using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IBankAccount
    {
        public bool WithdrawMoney(double amount);
        public bool DepositMoney(double amount);
        public double GetAvailableAmount();
        public bool IsPinValid(string pincode);
        public CreditCard CreateCreditCard(string firstname, string lastname, string pincode);
    }
}
