using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class RightAngledTriangle:Triangle
    {
        public RightAngledTriangle(double side_a,double side_b)
        {
            this.Side_a = side_a;
            this.Side_b = side_b;
            this.Side_c = CalculateHypotenuse();
        }

        private double CalculateHypotenuse()
        {
            return Math.Sqrt(Math.Pow(Side_a, 2) + Math.Pow(Side_b, 2));
        }

        public override double Area()
        {
            return 0.5 * Side_a * Side_b;
        }

        public override double Perimeter()
        {
            return Side_a + Side_b + Side_c;
        }

        public double AngleA()
        {
            return RadiansToDegrees(Math.Asin(Side_a / Side_c));
        }
        public double AngleB()
        {
            return RadiansToDegrees(Math.Asin(Side_b / Side_c));
        }

        private double RadiansToDegrees(double radians)
        {
            return (180 / Math.PI) * radians;
        }
    }
}
