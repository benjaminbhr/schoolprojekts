using ATM;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Moq;
using NSubstitute.Extensions;

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
            var bankaccount = CreateAccount();

            //Act
            var actual = bankaccount.IsPinValid(pincode);

            //Assert
            actual.ShouldBe(expected);
        }

        [TestCase(-1000, 2000, 2000)]
        [TestCase(0, 500, 500)]
        [TestCase(20000, 200000, 180000)]
        public void Withdraw_Money_Test(double amount, double availableAmount, double expected)
        {
            //Arrange
            var bankaccount = CreateAccount();
            bankaccount.AvailableAmount = availableAmount;

            //Act
            bankaccount.WithdrawMoney(amount);
            var actual = bankaccount.AvailableAmount;

            //Assert
            actual.ShouldBe(expected);
        }

        [TestCase]
        //This test case does not test anything specific, in the current state of this app, i found it hard to find a reason to mock anything
        //So this is just to show some mocking
        public void CreateCreditCard_Should_Be_Successfull()
        {
            //Here i chose to do a partial mocking of BankAccount class, I did this to be able to mock certain methods
            //And use other methods as they were originally implemented.
            var ba = Substitute.ForPartsOf<BankAccount>("testName","testLastName");
            //Here i mock the method (IsPinValid) to return true on any args, -- It will always return true.
            ba.Configure().IsPinValid(Arg.Any<string>()).ReturnsForAnyArgs(true);

            //Here i call the CreateCreditCard with an INVALID pincode, but because i mocked the pincode validation method to always be true
            //This method will also succeed, resulting in a credit card with pincode - weqr
            var card = ba.CreateCreditCard("testname", "testlastname", "weqr");

            //Asserting the object is not null.
            card.ShouldNotBeNull();
        }

        public BankAccount CreateAccount()
        {
            return new("testname", "testlastname");
        }

    }
}
