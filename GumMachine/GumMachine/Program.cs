using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumMachine
{
    class Program
    {
        /// <summary>
        /// Get the userinput
        /// </summary>
        /// <returns>The key that was pressed and other information like SHIFT, ALT was pressed etc</returns>
        static ConsoleKeyInfo UserKeyInput()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            return cki;
        }
        /// <summary>
        /// This method refills the list of gum in the Machine class
        /// </summary>
        static void FillDispenser()
        {
            GumStorage gumstorage = GumStorage.Instance;
            Dispenser dispenser = Dispenser.Instance;
            for (int i = 0; i < 55; i++)
            {
                dispenser.gums.Add(gumstorage.gumStorage.ElementAt(i));
            }
            gumstorage.gumStorage.Clear();
        }
        static void Menu(Dispenser dispenser,GumStorage gumStorage)
        {
            bool showmenu = true;
            while (showmenu)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine(" Welcome to this Gum Dispenser!");
                Console.WriteLine("================================");
                Console.WriteLine("(1) To turn the knob and draw a piece gum");
                Console.WriteLine("(2) Order new package of gum (if empty only)");
                Console.WriteLine("(3) Refill dispenser (if empty only)");
                Console.WriteLine("(4) Exit\n");
                Console.WriteLine("Gum left :"+dispenser.gums.Count);
                Console.WriteLine("Gum storage :" + gumStorage.gumStorage.Count);
                switch (UserKeyInput().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        try
                        {
                            Gum tempgum = dispenser.DrawGum();
                            Console.WriteLine($"You have recieved a {tempgum.Flavour} flavoured gum!\n");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("There aren't any gum left!");
                        }
                        Console.WriteLine("Press 'Enter' to go back to the main menu!");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        if (gumStorage.gumStorage.Count == 0)
                        {
                            gumStorage.OrderGum();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You still have gum in storage, use that first!");
                            Console.WriteLine("Press 'Enter' to return to the menu");
                            Console.ReadLine();
                        }
                        break;
                    case ConsoleKey.D3:
                        if (dispenser.gums.Count == 0)
                        {
                            try
                            {
                                FillDispenser();
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                Console.WriteLine("There's no gum in storage, please order more!");
                                Console.WriteLine("Press 'Enter' to go back to the menu!");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There are still gum left in the dispenser!");
                            Console.WriteLine("Press 'Enter' to return to the menu");
                            Console.ReadLine();
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
        static void Main(string[] args)
        {
            FillDispenser();
            Menu(Dispenser.Instance,GumStorage.Instance);
            Console.ReadLine();
        }
    }
}
