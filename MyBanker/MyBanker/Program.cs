using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Program
    {
        public static void GenerateCardUI(Card card)
        {
            Console.WriteLine("This is your new Card!");
            Console.WriteLine("Name: " + card.Name);
            Console.WriteLine("Age: " + card.Age);
            Console.WriteLine("Card Number: " + card.CardNumber);
            Console.WriteLine("Expiry Date: " + card.ExpiryDate);
            Console.WriteLine("Account Number: " + card.AccountNumber);
            Console.WriteLine("Registration Number: " + card.RegistrationNumber);
        }

        public static void SetCreditState(ICreditCard card,bool yesorno)
        {
            if (yesorno)
            {
                card.HasCredit = yesorno;
                Console.WriteLine($"Has credit: {card.HasCredit}");
                Console.WriteLine($"Has credit: {card.CreditAmount}");
            }
            else
            {
                card.HasCredit = yesorno;
                Console.WriteLine("This card cannot overdraw!");
            }
        }
        static void Main(string[] args)
        {
            bool continueProgram = true;
            while (continueProgram)
            {
                string name = "";
                int age;
                Console.WriteLine("Welcome to MyBanker!");
                Console.Write($"Please enter your name:");
                name = Console.ReadLine();
                Console.Clear();
                Console.Write("Please enter your age: ");
                age = Int32.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Now it's time to choose a Bank Account type!");
                Console.WriteLine("[1] Normal account");
                Console.WriteLine("[2] Savings account");
                ConsoleKey bankAcc = Console.ReadKey().Key;
                Console.Clear();
                switch (bankAcc)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("You have chosen a 'Normal Account'");
                        if (age >= 18)
                        {
                            bool overdraw = true;
                            Console.WriteLine("Do you want to be able to overdraw?");
                            Console.WriteLine("[1] yes");
                            Console.WriteLine("[2] no");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    overdraw = true;
                                    break;
                                case ConsoleKey.D2:
                                    overdraw = false;
                                    break;
                            }
                            Console.Clear();
                            Console.WriteLine("These are your card options based on age and Account");
                            Console.WriteLine("[1] VisaDankort");
                            Console.WriteLine("[2] MasterCard");
                            Console.WriteLine("[3] VisaElectron");
                            Console.WriteLine("[4] Maestro");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Account account1 = new Account(name, age, ECardType.VisaDankort);
                                    var visaCard = account1.AccountCard;
                                    GenerateCardUI(visaCard);
                                    SetCreditState(((ICreditCard)visaCard), overdraw);
                                    break;
                                case ConsoleKey.D2:
                                    Console.Clear();
                                    Account account2 = new Account(name, age, ECardType.MasterCard);
                                    var masterCard = account2.AccountCard;
                                    GenerateCardUI(masterCard);
                                    SetCreditState(((ICreditCard)masterCard), overdraw);
                                    break;
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    Account account3 = new Account(name, age, ECardType.VisaElectron);
                                    var visaelectronCard = account3.AccountCard;
                                    GenerateCardUI(visaelectronCard);
                                    break;
                                case ConsoleKey.D4:
                                    Console.Clear();
                                    Account account4 = new Account(name, age, ECardType.Maestro);
                                    var maestro = account4.AccountCard;
                                    GenerateCardUI(maestro);
                                    break;
                            }
                        }
                        else if (age >= 15)
                        {
                            Console.WriteLine("[1] Visa Electron");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Account account1 = new Account(name, age, ECardType.VisaElectron);
                                    var visaCard = account1.AccountCard;
                                    GenerateCardUI(visaCard);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("[1] WithdrawelCard");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Account account1 = new Account(name, age, ECardType.WithdrawelCard);
                                    var withdrawel = account1.AccountCard;
                                    GenerateCardUI(withdrawel);
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}
