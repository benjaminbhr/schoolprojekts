using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CocktailsConsole
{
    public class AlcoholBrand
    {
        [Key]
        public int AlcBrandId { get; set; }
        public string Name { get; set; }
    }
}
