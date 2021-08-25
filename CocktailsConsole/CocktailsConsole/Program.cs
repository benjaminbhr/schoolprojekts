using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CocktailsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CocktailContext())
            {
                var cocktail = new Cocktail()
                {
                    AlcoholBrand = new List<Alcohol>()
                    {
                        new Alcohol()
                        {
                            Name = "Bourbon",
                            Amount = "90ml"
                        }
                    },
                    IngredientBrand = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "Lime Juice",
                            Amount = "40ml"
                        }
                    },
                    Name = "Whiskey Sour"
                };
            }
            while (true)
            {
                Console.WriteLine("Welcome to BoozedBoys");
                Console.WriteLine("1) See all cocktails!");
                Console.WriteLine("2) Search for a specific drink");
                Console.WriteLine("3) Remove Cocktail");
                Console.WriteLine("4) Update Cocktail");
                Console.WriteLine("5) Create Cocktail");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        var testing = CocktailManager.GetAllCocktails();
                        PrintCocktails(testing);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Please enter the Alcohol, ingredient or the actual name of cocktail you want.");
                        var cocktailInput = Console.ReadLine();
                        var templist = CocktailManager.GetDesiredCocktails(cocktailInput);
                        PrintCocktails(templist);
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Please enter the cocktail name to remove");
                        var removeName = Console.ReadLine();
                        var templist2 = CocktailManager.DeleteCocktail(removeName);
                        Console.WriteLine($"This many cocktails have been removed : {templist2}");
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Please enter the cocktail name to remove");
                        var updateDrinkName = Console.ReadLine();
                        var updateDrinkDesiredName = Console.ReadLine();
                        var templist3 = CocktailManager.UpdateCocktailName(updateDrinkName, updateDrinkDesiredName);
                        Console.WriteLine($"This many cocktails have been updated : {templist3}");
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Please enter the cocktail name to create");
                        var cocktaileCreateName = Console.ReadLine();
                        Console.WriteLine("Please enter the Alcohol ingredients you want in the cocktail");
                        bool alcLoop = true;
                        bool ingrLoop = true;
                        List<string> alcohols = new List<string>();
                        List<string> alcoholsAmount = new List<string>();
                        List<string> ingredients = new List<string>();
                        List<string> ingredientsAmount = new List<string>();
                        while (alcLoop)
                        {
                            Console.WriteLine("Please enter Alcohol Name");
                            alcohols.Add(Console.ReadLine());
                            Console.WriteLine("Please enter the Amount");
                            alcoholsAmount.Add(Console.ReadLine());
                            Console.WriteLine("Do you wish to add more?");
                            Console.WriteLine("1) yes");
                            Console.WriteLine("2) no");
                            var decision = Console.ReadKey();
                            alcLoop = decision.Key == ConsoleKey.D1 ? true : false;
                            Console.Clear();
                        }
                        while (ingrLoop)
                        {
                            Console.WriteLine("Please enter Ingredient Name");
                            alcohols.Add(Console.ReadLine());
                            Console.WriteLine("Please enter the Amount");
                            alcoholsAmount.Add(Console.ReadLine());
                            Console.WriteLine("Do you wish to add more?");
                            Console.WriteLine("1) yes");
                            Console.WriteLine("2) no");
                            var decision = Console.ReadKey();
                            ingrLoop = decision.Key == ConsoleKey.D1 ? true : false;
                            Console.Clear();
                        }
                        CocktailManager.CreateCocktail(cocktaileCreateName, alcohols, alcoholsAmount, ingredients, ingredientsAmount);
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }


        }

        public static void PrintCocktails(List<Cocktail> cocktails)
        {
            foreach (var item in cocktails)
            {
                Console.WriteLine("\nDrink" + " : " + item.Name);
                Console.WriteLine("Ingredients");
                foreach (var alcoholAndAmount in item.AlcoholBrand)
                {
                    Console.WriteLine(alcoholAndAmount.Name + " : " + alcoholAndAmount.Amount);
                }
                foreach (var ingredientAndAmount in item.IngredientBrand)
                {
                    Console.WriteLine(ingredientAndAmount.Name + " : " + ingredientAndAmount.Amount);
                }
            }
        }
    }
}
