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
        public static List<Cocktail> GetAllCocktails(out CocktailContext testcontext)
        {
            using (var context = new CocktailContext())
            {
                var testing = from cocktrais in context.Cocktail.AsTracking() select cocktrais;
                var maybe = testing.ToList();
                testcontext = context;
                return maybe;
            }
        }
    }
}
