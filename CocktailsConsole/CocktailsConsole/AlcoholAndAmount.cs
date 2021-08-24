using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsConsole
{
    public class AlcoholAndAmount
    {
        [Key]
        public int Id { get; set; }
        public virtual AlcoholBrand AlcoholBrand { get; set; }
        public string Amount { get; set; }
    }
}
