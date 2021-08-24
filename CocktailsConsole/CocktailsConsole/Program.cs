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
                    AlcoholBrand = new List<AlcoholAndAmount>()
                    {
                        new AlcoholAndAmount()
                        {
                            AlcoholBrand = new AlcoholBrand()
                            {
                                Name = "Dark Rum"
                            },
                            Amount = "50ml"
                        }
                    },
                    IngredientBrand = new List<IngredientAndAmount>()
                    {
                        new IngredientAndAmount()
                        {
                            IngredientBrand = new IngredientBrand()
                            {
                                Name = "Orange Curacao"
                            },
                            Amount = "15ml"
                        },
                        new IngredientAndAmount()
                        {
                            IngredientBrand = new IngredientBrand()
                            {
                                Name = "Lime Juice"
                            },
                            Amount = "10ml"
                        },
                        new IngredientAndAmount()
                        {
                            IngredientBrand = new IngredientBrand()
                            {
                                Name = "Almond Syrup"
                            },
                            Amount = "60ml"
                        }
                    },
                    Name = "Mai Tai"
                };

            }
            Console.WriteLine("Welcome to BoozedBoys");
            Console.WriteLine("1) See all cocktails!");
            Console.WriteLine("2) Search for a specific alcohol");
            Console.WriteLine("3) Change Cocktail ingredient amounts!");
            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    break;
            }

            Console.ReadKey();


        }

        public static void PrintCocktails(List<Cocktail> cocktails)
        {
            foreach (var item in cocktails)
            {
                Console.WriteLine("Drink" + ":" + item.Name);
                Console.WriteLine("\nIngredients");
                foreach (var alcoholAndAmount in item.AlcoholBrand)
                {
                    Console.WriteLine(alcoholAndAmount.AlcoholBrand.Name + ":" + alcoholAndAmount.Amount);
                }
                foreach (var ingredientAndAmount in item.IngredientBrand)
                {
                    Console.WriteLine(ingredientAndAmount.IngredientBrand.Name + ":" + ingredientAndAmount.Amount);
                }
            }
        }
    }
}
