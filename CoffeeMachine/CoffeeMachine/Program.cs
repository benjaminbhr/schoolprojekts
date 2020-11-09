using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            IHotDrinkMachine machine = new StandardCoffeeMachine();
            IHotDrinkMachine machine2 = new EspressoMachine();
            Console.WriteLine(machine2.BrewProduct(2));
            Console.ReadLine();
        }
    }
}
