using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace CocktailsConsole
{
    public static class CocktailManager
    {
        public static List<Cocktail> GetAllCocktails()
        {
            using (var context = new CocktailContext())
            {
                var testing = context.Cocktail.
                    Include(e => e.AlcoholBrand).
                    Include(e => e.IngredientBrand);
                var maybe = testing.ToList();
                return maybe;
            }
        }

        public static List<Cocktail> GetDesiredCocktails(string input)
        {
            using (var context = new CocktailContext())
            {
                var testing = context.Cocktail.Where(e => e.Name.Equals(input) || e.AlcoholBrand.Where(u => u.Name.Equals(input)).Any() || e.IngredientBrand.Where(u => u.Name.Equals(input)).Any()).
                    Include(e => e.AlcoholBrand).
                    Include(e => e.IngredientBrand);
                var maybe = testing.ToList();
                return maybe;
            }
        }

        public static int DeleteCocktail(string cocktailName)
        {
            using (var context = new CocktailContext())
            {
                var tempo = context.Cocktail.Where(e => e.Name.Equals(cocktailName)).
                    Include(e => e.AlcoholBrand).
                    Include(e => e.IngredientBrand);
                var testing = context.Cocktail.Remove(tempo.FirstOrDefault());
                return context.SaveChanges();
            }
        }

        public static int UpdateCocktailName(string cocktailName,string desiredCocktailName)
        {
            using (var context = new CocktailContext())
            {
                var tempo = context.Cocktail.Where(e => e.Name.Equals(cocktailName)).
                    Include(e => e.AlcoholBrand).
                    Include(e => e.IngredientBrand);
                tempo.FirstOrDefault().Name = desiredCocktailName;
                var testing = context.Cocktail.Update(tempo.FirstOrDefault());
                return context.SaveChanges();
            }
        }

        public static int CreateCocktail(string cocktailName,List<string> alcohols, List<string> alcoholsAmount, List<string> ingredients, List<string> ingredientsAmount)
        {
            var alcoholslist = new List<Alcohol>();
            var ingredientlist = new List<Ingredient>();
            for (int i = 0; i < alcohols.Count; i++)
            {
                var temp = new Alcohol()
                {
                    Name = alcohols[i],
                    Amount = alcoholsAmount[i]
                };
                alcoholslist.Add(temp);
            }
            for (int i = 0; i < ingredients.Count; i++)
            {
                var temp = new Ingredient()
                {
                    Name = ingredients[i],
                    Amount = ingredientsAmount[i]
                };
                ingredientlist.Add(temp);
            }

            var cocktail = new Cocktail()
            {
                Name = cocktailName,
                AlcoholBrand = alcoholslist,
                IngredientBrand = ingredientlist
            };

            using (var context = new CocktailContext())
            {
                context.Add(cocktail);
                return context.SaveChanges();
            }
        }
    }
}
