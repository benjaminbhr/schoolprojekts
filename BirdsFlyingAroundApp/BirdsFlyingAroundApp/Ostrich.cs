using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAroundApp
{
    public class Ostrich:Bird
    {
        public override string Eat()
        {
            return "I primarily eat plants, roots, and seeds!";
        }

        public override string Sound()
        {
            return "I whistle, hoot and hiss!";
        }
    }
}
