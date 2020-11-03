using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Square:Quadrilateral
    {
        public override double Area()
        {
            return Math.Pow(this.Side_a,2);
        }
        public override double Perimeter()
        {
            return 4 * this.Side_a;
        }

        public Square(double side_a)
        {
            this.Side_a = side_a;
        }
    }
}
