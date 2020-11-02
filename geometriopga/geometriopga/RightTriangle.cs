using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    public class RightTriangle : Triangle
    {
        /// <summary>
        /// This constructor assigns the values from the parameters to the correct props, 
        /// but it also checks if the triangle being made meets the requirements of a triangle, and sends an exception if it doesn't
        /// </summary>
        /// <param name="sidea"></param>
        /// <param name="sideb"></param>
        /// <param name="anglea"></param>
        /// <param name="angleb"></param>
        /// <param name="anglec"></param>
        public RightTriangle(double sidea, double sideb, double anglea, double angleb, double anglec)
        {
            if (IsRightTriangle(anglea,angleb,anglec))
            {
                this.Side_a = sidea;
                this.Side_b = sideb;
                this.Angle_a = anglea;
                this.Angle_b = angleb;
                CalcSideC();
            }
            else
            {
                throw new Exception("This is not a RightTriangle");
            }
        }

        private bool IsRightTriangle(double anglea,double angleb,double anglec)
        {
            if (anglea + angleb + anglec == 180 && anglea == 90 | angleb == 90 | anglec == 90)
            {
                TriangleType = ETriangleType.Right;
                return true;
            }
            else if (Angle_a == 90 && Angle_b == 90 | Angle_a == 90 && Angle_c == 90 | Angle_c == 90 && Angle_b == 90)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
