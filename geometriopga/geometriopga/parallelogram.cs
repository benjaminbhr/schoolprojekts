using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    public class Parallelogram : Square
    {
        private double degrees;

        public double Degrees
        {
            get { return degrees; }
            set { degrees = value; }
        }

        private double side_b;

        public double Side_b
        {
            get { return side_b; }
            set { side_b = value; }
        }




        public Parallelogram(double sidea, double sideb,double degrees) : base(sidea)
        {
            this.Side_b = sideb;
            this.Degrees = degrees;
            this.Squaretype = ESquareType.parallelogram;
        }
        public override double SquareArea()
        {
            double angle = Math.PI * Degrees / 180;
            return this.Side_a * this.Side_b * Math.Sin(angle);
        }

    }
}
