using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumMachine
{
    //Hvorfor er klassen sat til at være sealed? Hvad betyder det?
    //Fint at du har benyttet en singleton
    public sealed class Dispenser
    {
        public List<Gum> gums = new List<Gum>();
        /// <summary>
        /// This method generates a random number between 0 and to the count of the list, and stores that object in a temp variable, and then removes the object from the list
        /// </summary>
        /// <returns>The stored object</returns>
        public Gum DrawGum()
        {
            Gum tempgum;
            Random rnd = new Random();
            int random = rnd.Next(gums.Count);
            tempgum = gums.ElementAt(random);
            gums.RemoveAt(random);
            return tempgum;
        }

        private static Dispenser instance;

        private Dispenser()
        {
        }

        public static Dispenser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dispenser();
                }
                return instance;
            }
        }

    }
}
