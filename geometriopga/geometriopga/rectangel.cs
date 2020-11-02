using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    public class Rectangel:Square
    {
        private double side_b;

        public double Side_b
        {
            get { return side_b; }
            set { side_b = value; }
        }

        public Rectangel(double sidea,double sideb):base(sidea)
        {
            this.Squaretype = ESquareType.rectangle;
            this.Side_b = sideb;
        }

        public override double Area()
        {
            return Side_a * this.Side_b;
        }
    }
}
