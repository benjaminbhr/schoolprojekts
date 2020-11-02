using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    public class Square:Shapes
    {
        private double side_a;

        public virtual double Side_a
        {
            get { return side_a; }
        }

        private ESquareType squareType;

        public ESquareType Squaretype
        {
            get { return squareType; }
            protected set { squareType = value; }
        }



        public Square(double sidea)
        {
            this.side_a = sidea;
            this.Shape = EShapeType.square;
            this.Squaretype = ESquareType.square;
        }


        public double SquarePerimeter()
        {
            return this.side_a * 3;
        }
        public virtual double SquareArea()
        {
            return side_a * side_a;
        }
    }
}
        