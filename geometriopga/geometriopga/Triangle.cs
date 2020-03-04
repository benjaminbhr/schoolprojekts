using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    public class Triangle:Shapes
    {
		private ETriangleType triangletype;

		public ETriangleType TriangleType
		{
			get { return triangletype; }
			protected set { triangletype = value; }
		}


		private double side_a;

		public double Side_a
		{
			get { return side_a; }
			set { side_a = value; }
		}
		private double side_b;

		public double Side_b
		{
			get { return side_b; }
			set { side_b = value; }
		}
		private double side_c;

		public double Side_c
		{
			get { return side_c; }
			set { side_c = value; }
		}

		private double angle_a;

		public double Angle_a
		{
			get { return angle_a; }
			set { angle_a = value; }
		}

		private double angle_b;

		public double Angle_b
		{
			get { return angle_b; }
			set { angle_b = value; }
		}

		private double angle_c;

		public double Angle_c
		{
			get { return angle_c; }
			set { angle_c = value; }
		}

        /// <summary>
        /// Calculates the area of the triangle
        /// </summary>
        /// <returns></returns>
		public double TriangleArea()
		{
			if (Angle_a == 90)
			{
				return (Side_b * Side_c) / 2;
			}
			else if (Angle_b == 90)
			{
				return 0.5 * (Side_a * Side_c);
			}
			else
			{
				return 0.5 * (Side_a * Side_b);
			}
		}

        /// <summary>
        /// Calculates the perimiter of the triangle
        /// </summary>
        /// <returns></returns>
		public double TrianglePerimiter()
		{
			return this.Side_a + this.Side_b + this.Side_c;
		}

        /// <summary>
        /// Calculates the side C based on side A and side B
        /// </summary>
		public void CalcSideC()
		{
			double temp_c = Math.Pow(Angle_a, 2) * Math.Pow(Angle_b, 2);
			this.Angle_c = Math.Pow(temp_c, 2);
		}


        /// <summary>
        /// This constructor assigns the values from the parameters to the correct props, 
        /// but it also checks if the triangle being made meets the requirements of a triangle, and sends an exception if it doesn't
        /// </summary>
        /// <param name="sidea"></param>
        /// <param name="sideb"></param>
        /// <param name="anglea"></param>
        /// <param name="angleb"></param>
        /// <param name="anglec"></param>
		public Triangle(double sidea, double sideb, double anglea, double angleb, double anglec)
		{
			this.Side_a = sidea;
			this.Side_b = sideb;
			this.Angle_a = anglea;
			this.Angle_b = angleb;
			this.Shape = EShapeType.triangle;

			if (anglea + angleb + anglec == 180 && anglea == 90 | angleb == 90 | anglec == 90)
			{
				TriangleType = ETriangleType.Right;
				this.TriangleType = ETriangleType.Right;
			}
			else if (Angle_a == 90 && Angle_b == 90 | Angle_a == 90 && Angle_c == 90 | Angle_c == 90 && Angle_b == 90)
			{
				throw new Exception("This form is not a triangle!");
			}
			else
			{
				throw new Exception("This form is not a triangle!");
			}
		}



	}
}
