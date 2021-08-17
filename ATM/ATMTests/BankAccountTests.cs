using ATM;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTests
{
    [TestFixture]
    public class BankAccountTests
    {

        [TestCase("1234", true)]
        [TestCase("8392", true)]
        [TestCase("DW23", false)]
        [TestCase("@od29", false)]
        [TestCase("1234567", false)]
        [TestCase("jek23", false)]
        [TestCase("´+´''´'", false)]
        public void Is_Pincode_Valid(string pincode, bool expected)
        {
            //Arrange
            var bankaccount = CreateDummyAccount();

            //Act
            var actual = bankaccount.isPinValid(pincode);

            //Assert
            actual.ShouldBe(expected);
        }

        [TestCase(1000, 2000, 1000)]
        [TestCase(1000, 500, 500)]
        [TestCase(20000, 200000, 180000)]
        public void Withdraw_Money_Test(double amount, double availableAmount, double expected)
        {
            //Arrange
            var bankaccount = CreateDummyAccount();
            bankaccount.AvailableAmount = availableAmount;

            //Act
            bankaccount.WithdrawMoney(amount);
            var actual = bankaccount.AvailableAmount;

            //Assert
            actual.ShouldBe(expected);
        }


        public BankAccount CreateDummyAccount()
        {
            return new BankAccount("testName", "testLastname");
        }

    }
}
