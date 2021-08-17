using System;

namespace ATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Benjamin", "Roesdal");
            account.CreateCreditCard("Benjamin","Roesdal","1234");
            ATM atm = new ATM();

            while (true)
            {
                Console.WriteLine("Welcome to Banjo's ATM!");
                Console.WriteLine("1) to Withdraw money");
                Console.WriteLine("2) to Deposit money");
                Console.WriteLine("3) to show money");
                var key = Console.ReadKey();
                switch (key.Key)    
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Please enter pincode and Amount after");
                        Console.WriteLine(atm.Withdraw(account.CreditCard, Console.ReadLine(), Int32.Parse(Console.ReadLine())));
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Please enter pincode and Amount after");
                        Console.WriteLine(atm.Deposit(account.CreditCard, Console.ReadLine(), Int32.Parse(Console.ReadLine())));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Please enter pincode");
                        Console.WriteLine(atm.ShowAmount(account.CreditCard, Console.ReadLine()));
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
