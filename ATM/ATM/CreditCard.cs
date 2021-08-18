using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CreditCard
    {
        public string PinCode { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IBankAccount BankAccount { get; set; }

        public CreditCard(string firstname,string lastname,string pincode,IBankAccount bankAccount)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PinCode = pincode;
            this.ExpiryDate = DateTime.Now.AddYears(5);
            this.CardNumber = GenerateCardNumber();
            this.CVC = GenerateCvc();
            this.BankAccount = bankAccount;
        }

        public string GenerateCardNumber()
        {
            Random rnd = new Random();
            var builder = new StringBuilder();
            while (builder.Length < 16)
            {
                builder.Append(rnd.Next(10).ToString());
            }
            return builder.ToString();
        }

        public string GenerateCvc()
        {
            Random rnd = new Random();
            var builder = new StringBuilder();
            while (builder.Length < 3)
            {
                builder.Append(rnd.Next(10).ToString());
            }
            return builder.ToString();
        }

        public string Withdraw(string pincode,double amount)
        {
            if (PinCode == pincode)
            {
                if (BankAccount.WithdrawMoney(amount))
                {
                    return $"{amount} has successfully been withdrawn from the account";
                }
                else
                {
                    return $"{amount} could not be withdrawn";
                }
            }
            else
            {
                return "Wrong pincode";
            }
        }

        public string Deposit(string pincode, double amount)
        {
            if (PinCode == pincode)
            {
                if (BankAccount.DepositMoney(amount))
                {
                    return $"{amount} has successfully been deposited to the account";
                }
                else
                {
                    return $"{amount} could not deposit";
                }
            }
            else
            {
                return "Wrong pincode";
            }
        }
    }
}
