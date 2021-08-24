using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CocktailsConsole
{
    public class Cocktail
    {
        private int cocktailId;

        [Key]
        public int CocktailId
        {
            get { return cocktailId; }
            set { cocktailId = value; }
        }

        public string Name { get; set; }
        public virtual List<AlcoholAndAmount> AlcoholBrand { get; set; }
        public virtual List<IngredientAndAmount> IngredientBrand { get; set; }


        public Cocktail()
        {
            
        }
    }
}
