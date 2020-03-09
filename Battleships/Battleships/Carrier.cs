using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Carrier:Ship
    {
        private string name = "Carrier";

        public string Name
        {
            get { return name; }
        }


        public Carrier() :base(5)
        {
        }
    }
}
