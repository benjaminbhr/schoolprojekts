using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsConsole
{
    public class Alcohol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public string Amount { get; set; }
    }
}
