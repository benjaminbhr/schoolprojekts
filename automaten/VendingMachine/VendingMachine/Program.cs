using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static ConsoleKeyInfo UserKeyInput()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            return cki;
        }
        static int UserPriceInput()
        {
            int usermoney = int.Parse(Console.ReadLine());
            return usermoney;
        }
        static Machine machine = new Machine();
        static void Menu()
        {
            int colaprice = 18;
            int chipsprice = 11;
            int drinkindex = 0;
            int snackindex = 0;
            bool showmenu = true;
            bool caserunning = true;
            while (showmenu)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("Welcome to this vending machine!");
                Console.WriteLine("================================");
                Console.WriteLine("(1) Coca-Cola - {0}", 18 + " " + "Dkk" + $"- {machine.DrinksLeft()} left");
                Console.WriteLine("(2) Sour-Creme chips - {0}", 11 + " " + "Dkk" + $"- {machine.SnacksLeft()} left");
                Console.WriteLine("(3) Administrator menu");
                Console.WriteLine("(4) Exit");
                switch (UserKeyInput().Key)
                {
                    case ConsoleKey.D1:

                        if (drinkindex == 5)
                        {
                            Console.WriteLine("This product is sold out!.");
                            Console.WriteLine("Press any key to return to menu");
                            Console.ReadKey();
                            caserunning = false;
                        }
                        else if (drinkindex < 5)
                        {
                            caserunning = true;
                        }
                        Console.WriteLine("Please insert {0}", colaprice + " " + "Dkk");
                        int drinktempmoney = UserPriceInput();
                        while (caserunning)
                        {
                            int rest;
                            if (drinktempmoney >= colaprice)
                            {
                                int moneyback = drinktempmoney - colaprice;
                                caserunning = false;
                                Console.WriteLine("\nYou inserted {0}", drinktempmoney + $" You get {moneyback} back");
                                Console.WriteLine($"You have purchased\n{machine.drinkstorage[drinkindex].Name}\n{machine.drinkstorage[drinkindex].Amount}ml\n{machine.drinkstorage[drinkindex].Container}\nCost:{colaprice}");
                                Console.WriteLine("Press any key to return to menu");
                                Console.ReadKey();
                                machine.drinkstorage[drinkindex] = null;
                                drinkindex++;
                            }
                            else
                            {
                                rest = colaprice - drinktempmoney;
                                Console.WriteLine("You need to insert {0}", rest, "more to buy this drink");
                                drinktempmoney += UserPriceInput();
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        caserunning = true;
                        if (snackindex == 5)
                        {
                            Console.WriteLine("This product is sold out!.");
                            Console.WriteLine("Press any key to return to menu");
                            Console.ReadKey();
                            caserunning = false;
                        }
                        Console.WriteLine("Please insert {0}", chipsprice + " " + "Dkk");
                        int snacktempmoney = UserPriceInput();
                        while (caserunning)
                        {
                            int rest;
                            if (snacktempmoney >= chipsprice)
                            {
                                int moneyback = snacktempmoney - chipsprice;
                                caserunning = false;
                                Console.WriteLine("\nYou inserted {0}", snacktempmoney + $" You get {moneyback} back");
                                Console.WriteLine($"You have purchased\n{machine.snackstorage[snackindex].Name}\n{machine.snackstorage[snackindex].Amount}grams\nCost:{chipsprice}Dkk");
                                Console.WriteLine("Press any key to return to menu");
                                Console.ReadKey();
                                machine.snackstorage[snackindex] = null;
                                snackindex++;
                            }
                            else
                            {
                                rest = chipsprice - snacktempmoney;
                                Console.WriteLine("You need to insert {0}", rest, "more to buy this drink");
                                snacktempmoney = snacktempmoney + UserPriceInput();
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Administrator mode, insert admin code to open machine 'code is :3220' for testing purposes");
                        int tempadminkey = int.Parse(Console.ReadLine());
                        if (machine.AdminLogin(tempadminkey))
                        {
                            Console.WriteLine("(1) To refill Drinks\n(2) to refill snacks\n(3) return to main menu");
                            switch (UserKeyInput().Key)
                            {
                                case ConsoleKey.D1:
                                    machine.FillDrinkStorage();
                                    break;
                                case ConsoleKey.D2:
                                    machine.FillSnackStorage();
                                    break;
                                case ConsoleKey.D3:
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D4:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        static void Transaction()
        {

        }
        static void Main(string[] args)
        {
            machine.FillDrinkStorage();
            machine.FillSnackStorage();
            Menu();
        }
    }
}
