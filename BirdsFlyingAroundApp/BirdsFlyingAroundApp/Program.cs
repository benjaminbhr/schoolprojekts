using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAroundApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird sparrow = new Sparrow();
            Console.WriteLine("I'm a " + sparrow.GetType().Name);
            Console.WriteLine(((IFly)sparrow).Fly());
            Console.WriteLine(sparrow.Eat());
            Console.WriteLine(sparrow.Sound() + "\n");

            Bird ostrich = new Ostrich();
            Console.WriteLine("I'm a " + ostrich.GetType().Name);
            Console.WriteLine(ostrich.Eat());
            Console.WriteLine(ostrich.Sound());
            Console.ReadLine();
        }
    }
}
