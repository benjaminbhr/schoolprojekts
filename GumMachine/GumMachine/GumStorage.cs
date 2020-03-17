using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumMachine
{
    public class GumStorage
    {
        public List<Gum> gumStorage = new List<Gum>();

        public void OrderGum()
        {
            int applecount = 0;
            int blueberrycount = 0;
            int blackberrycount = 0;
            int tuttifrutticount = 0;
            int orangecount = 0;
            int strawberrycount = 0;
            for (int i = 0; i < 55; i++)
            {
                if (applecount < 6)
                {
                    gumStorage.Add(new Gum("Apple"));
                    applecount++;
                }
                else if (blueberrycount < 13)
                {
                    gumStorage.Add(new Gum("Blue Berry"));
                    blueberrycount++;
                }
                else if (blackberrycount < 6)
                {
                    gumStorage.Add(new Gum("Black Berry"));
                    blackberrycount++;
                }
                else if (tuttifrutticount < 11)
                {
                    gumStorage.Add(new Gum("Tutti Frutti"));
                    tuttifrutticount++;
                }
                else if (orangecount < 11)
                {
                    gumStorage.Add(new Gum("Orange"));
                    orangecount++;
                }
                else if (strawberrycount < 8)
                {
                    gumStorage.Add(new Gum("Strawberry"));
                    strawberrycount++;
                }
            }
        }
        //This is the created instance, since Machine ctor is private, and there's only a Get on the Instance prop, it will only be possible to create new instances of Machine from inside this Machine class.
        internal static readonly GumStorage instance = new GumStorage();

        //This is a prop of type Machine, which returns instance
        public static GumStorage Instance { get { return instance; } }

        public GumStorage()
        {
            OrderGum();
        }
    }
}
