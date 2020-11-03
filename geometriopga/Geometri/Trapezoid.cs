using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Trapezoid : Quadrilateral
    {
        private double side_c;

        public double Side_c
        {
            get { return side_c; }
            private set { side_c = value; }
        }

        private double side_b;

        public double Side_b
        {
            get { return side_b; }
            private set { side_b = value; }
        }

        private double side_d;

        public double Side_d
        {
            get { return side_d; }
            private set { side_d = value; }
        }

        public double CalcSValue()
        {
            double s = (Side_a + Side_b - Side_c + Side_d) / 2;
            return s;
        }

        public double CalcHeight()
        {
            double s_value = CalcSValue();
            return 2 / (Side_a - Side_c) * (Math.Sqrt(s_value * (s_value - Side_a + Side_c) * (s_value - Side_b) * (s_value - Side_d)));
        }

        public override double Area()
        {
            return 0.5 * (Side_a + Side_c) * CalcHeight();
        }
        public override double Perimeter()
        {
            return Side_a + Side_b + Side_c + Side_d;
        }

        public Trapezoid(double side_a,double side_c,double side_b)
        {
            this.Side_a = side_a;
            this.Side_c = side_c;
            this.Side_b = side_b;
            this.Side_d = side_b;
        }
    }
}
