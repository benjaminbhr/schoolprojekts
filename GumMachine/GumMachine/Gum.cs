using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumMachine
{
    public class Gum
    {
        private string flavour;

        public string Flavour
        {
            get { return flavour; }
            set { flavour = value; }
        }
        public Gum(string flavour)
        {
            this.Flavour = flavour;
        }

    }
}
