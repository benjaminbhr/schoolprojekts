using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AirTravelEntities())
            {
                //Gets all routes with owner id of 1
                var routes = context.Routes.Where(e=>e.Owner == 1).ToList();
                //Gets all airports with IATA equal to LAX
                var airport = context.Airports.Where(e=>e.IATA.Equals("LAX")).ToList();
                //Gets all airlines with code - SAS
                var airlines = context.Airlines.Where(e=>e.Code.Equals("SAS")).ToList();
                Console.ReadKey();
            }
        }
    }
}
