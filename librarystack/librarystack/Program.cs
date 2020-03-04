using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarystack
{
    class Program
    {
        static ConsoleKeyInfo UserInput()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            return cki;
        }
        static void Main(string[] args)
        {
            List<Book> booksInLib = new List<Book>();
            booksInLib.Add(new Book("Fire and Blood","Fantasy",736,"George R. R. Martin"));
            booksInLib.Add(new Book("A Storm of Swords", "Fantasy", 973, "George R. R. Martin"));
            booksInLib.Add(new Book("A Clash of Kings", "Fantasy", 761, "George R. R. Martin"));
            booksInLib.Add(new Book("A Game of Thrones", "Fantasy", 694, "George R. R. Martin"));
            Stack lendbooks = new Stack();
            bool showmenu = true;
            while (showmenu)
            {
                Console.Clear();
                Console.WriteLine("===============");
                Console.WriteLine("    Library");
                Console.WriteLine("===============");
                Console.WriteLine("(1) Add Books\n(2) Show book stack\n(3) Exit");
                switch (UserInput().Key)
                {
                    case ConsoleKey.D1:
                        if (booksInLib.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("There are no books left in the library!");
                            Console.WriteLine("\nPress enter to return to main menu!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write($"Please select a book\n");
                            for (int i = 0; i < booksInLib.Count; i++)
                            {
                                Console.WriteLine($"({(i+1)}){booksInLib.ElementAt(i).Name}\n");
                            }
                            switch (UserInput().Key)
                            {
                                case ConsoleKey.D1:
                                    lendbooks.Push(booksInLib.ElementAt(0));
                                    booksInLib.RemoveAt(0);
                                    break;
                                case ConsoleKey.D2:
                                    lendbooks.Push(booksInLib.ElementAt(1));
                                    booksInLib.RemoveAt(1);
                                    break;
                                case ConsoleKey.D3:
                                    lendbooks.Push(booksInLib.ElementAt(2));
                                    booksInLib.RemoveAt(2);
                                    break;
                                case ConsoleKey.D4:
                                    lendbooks.Push(booksInLib.ElementAt(3));
                                    booksInLib.RemoveAt(3);
                                    break;
                                default:
                                    break;
                            }
                        }
                        
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        bool caserunning = true;
                        while (lendbooks.Count > 0 && caserunning)
                        {
                            Console.WriteLine("Finish loan");
                            string temp_name = ((Book)lendbooks.Peek()).Name;
                            Console.WriteLine($"Would you like to lend ({temp_name}) ----- ({lendbooks.Count}) Books left in your stack!\n(1)Yes\n(2)No");
                            switch (UserInput().Key)
                            {
                                case ConsoleKey.D1:
                                    lendbooks.Pop();
                                    break;
                                case ConsoleKey.D2:
                                    caserunning = false;
                                    break;
                                default:
                                    break;
                            }
                            Console.Clear();
                        }
                        if (lendbooks.Count == 0)
                        {
                            Console.WriteLine("You have no books left in your stack!");
                            Console.WriteLine("\nPress enter to return to main menu!");
                            Console.ReadLine();
                        }
                        break;
                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
