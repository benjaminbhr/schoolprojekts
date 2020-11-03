using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public abstract class Quadrilateral:Shape
    {
        private double side_a;

        public double Side_a
        {
            get { return side_a; }
            protected set { side_a = value; }
        }
    }
}
