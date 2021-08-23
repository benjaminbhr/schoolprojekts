﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM
{
    public class BankAccount : IBankAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double AvailableAmount { get; set; }
        public CreditCard CreditCard { get; set; }

        public BankAccount(string firstname,string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public CreditCard CreateCreditCard(string firstname,string lastname,string pincode)
        {
            if (IsPinValid(pincode))
            {
                this.CreditCard = new CreditCard(firstname, lastname, pincode,this);
                return CreditCard;
            }
            return null;
        }

        public bool WithdrawMoney(double amount)
        {
            if (amount < AvailableAmount && amount > 0)
            {
                AvailableAmount = AvailableAmount - amount;
                return true;
            }
            return false;
        }

        public bool DepositMoney(double amount)
        {
            if (amount > 0)
            {
                AvailableAmount += amount;
                return true;
            }

            return false;
        }

        public double GetAvailableAmount()
        {
            return AvailableAmount;
        }

        public virtual bool IsPinValid(string pincode)
        {
            Regex rgx = new Regex("^[0-9]{4}$");
            bool isvalidpin = rgx.IsMatch(pincode);
            return isvalidpin;
        }
    }
}