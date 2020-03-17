using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumMachine
{
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

        /// <summary>
        /// Machine constructor is private so it can't be accessed in other classes to be used forexamble for instanciating.
        /// </summary>
        private Dispenser()
        {
        }

        //This is the created instance, since Machine ctor is private, and there's only a Get on the Instance prop, it will only be possible to create new instances of Machine from inside this Machine class.
        internal static readonly Dispenser instance = new Dispenser();

        //This is a prop of type Machine, which returns instance
        public static Dispenser Instance { get { return instance; } }

    }
}
