using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsConsole
{
    public class IngredientAndAmount
    {
        [Key]
        public int Id { get; set; }
        public virtual IngredientBrand IngredientBrand { get; set; }
        public string Amount { get; set; }
    }
}
