using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public abstract class Triangle:Shape
    {
        private double side_a;

        public double Side_a
        {
            get { return side_a; }
            protected set { side_a = value; }
        }

        private double side_b;

        public double Side_b
        {
            get { return side_b; }
            protected set { side_b = value; }
        }

        private double side_c;

        public double Side_c
        {
            get { return side_c; }
            protected set { side_c = value; }
        }

    }
}
