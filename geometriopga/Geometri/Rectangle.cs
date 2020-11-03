using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Rectangle:Quadrilateral
    {
        private double side_b;

        public double Side_b
        {
            get { return side_b; }
            private set { side_b = value; }
        }

        public Rectangle(double side_a,double side_b)
        {
            this.Side_a = side_a;
            this.Side_b = side_b;
        }

        public override double Area()
        {
            return Side_a * Side_b;
        }

        public override double Perimeter()
        {
            return Side_a * 2 + Side_b * 2;
        }
    }
}
