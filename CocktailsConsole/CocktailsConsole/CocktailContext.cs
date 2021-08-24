using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CocktailsConsole
{
    public class CocktailContext : DbContext
    {
        public DbSet<Cocktail> Cocktail { get; set; }
        public DbSet<IngredientBrand> Ingredients { get; set; }
        public DbSet<AlcoholBrand> Alcohols { get; set; }

        public CocktailContext(): base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=CocktailDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}
