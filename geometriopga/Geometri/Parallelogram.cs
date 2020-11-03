using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Parallelogram:Quadrilateral
    {
        private double side_b;

        public double Side_b
        {
            get { return side_b; }
            set { side_b = value; }
        }

        private double inclination;

        public double Inclination
        {
            get { return inclination; }
            set { inclination = value; }
        }


        public override double Area()
        {
            return Side_a * Side_b * Math.Sin(DegreesToRadian(Inclination));
        }

        public override double Perimeter()
        {
            return Side_a * 2 + Side_b * 2;
        }

        private double DegreesToRadian(double degree)
        {
            return degree * Math.PI / 180;
        }

        public Parallelogram(double side_a,double side_b, double inclination)
        {
            this.Side_a = side_a;
            this.Side_b = side_b;
            this.Inclination = inclination;
        }
    }
}
