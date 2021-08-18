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

        [TestCase()]
        public void CreateCreditCard_Should_Be_Successfull()
        {
            var ba = Substitute.ForPartsOf<BankAccount>("testName","testLastName");
            ba.Configure().IsPinValid(Arg.Any<string>()).ReturnsForAnyArgs(true);

            var card = ba.CreateCreditCard("testname", "testlastname", "weqr");

            card.ShouldNotBeNull();
        }


        public IBankAccount CreateDummyAccount()
        {
            var ba = Substitute.For<IBankAccount>();
            ba.IsPinValid(Arg.Any<string>()).Returns(true);
            return ba;
        }

        public BankAccount CreateAccount()
        {
            return new("testname", "testlastname");
        }

    }
}
