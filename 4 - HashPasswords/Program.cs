﻿using System;
using System.Text;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Hello");
                Console.WriteLine("[1] to login");
                Console.WriteLine("[2] to create account");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Please login!");
                        Console.Write("Username: ");
                        var userName = Console.ReadLine();
                        Console.Write("Password: ");
                        var userPW = Console.ReadLine();
                        Login login = new Login();
                        Console.WriteLine(login.TryLogin(userName, userPW));
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Account account = new Account();
                        Console.Write("Username: ");
                        string usname = Console.ReadLine();
                        Console.Write("Password: ");
                        string pw = Console.ReadLine();
                        account.CreateAccount(usname,pw);
                        break;
                }
            }
        }
    }
}
