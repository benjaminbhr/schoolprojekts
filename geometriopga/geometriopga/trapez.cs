using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    public class Trapez : Square
    {
        private double side_b;

        public double Side_b
        {
            get { return side_b; }
            private set { side_b = value; }
        }
        private double side_c;

        public double Side_c
        {
            get { return side_c; }
            private set { side_c = value; }
        }


        private double side_d;

        public double Side_d
        {
            get { return side_d; }
            private set { side_d = value; }
        }

        public double CalcHeight()
        {
            double s_value = (this.Side_a + Side_b - Side_c + Side_d) / 2;
            double height = 2 / (Side_a - Side_c) * (Math.Sqrt(s_value * (s_value - Side_a + Side_c) * (s_value - Side_b) * (s_value - Side_d)));
            return height;
        }
        
        public override double Area()
        {
            return (Side_a + Side_c) * CalcHeight() / 2;
        }

        /// <summary>
        /// This constructor takes in 3 paramaters and a 4th that is required for the superclass Squares constructor.
        /// </summary>
        /// <param name="sidea">Side a of a Trapez</param>
        /// <param name="sidec">Side c of a Trapez</param>
        /// <param name="sideb">Side b of a Trapez</param>
        /// <param name="sided">Side d of a Trapez</param>
        public Trapez(double sidea,double sidec,double sideb,double sided):base(sidea)
        {
            this.Side_c = sidec;
            this.Side_b = sideb;
            this.Side_d = sided;
            this.Squaretype = ESquareType.trapez;
        }
    }
}
