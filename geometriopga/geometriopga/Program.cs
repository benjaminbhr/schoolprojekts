using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shapes> shapes = new List<Shapes>();
            //This is where i "try" to instanciate all my objects and add them to the list.
            try
            {
                Triangle right_triangle = new Triangle(50, 10, 45,45,90);
                Square square = new Square(5);
                Parallelogram parallelogram = new Parallelogram(3, 5, 20);
                Trapez trapez = new Trapez(10, 8, 9, 9);
                Rectangel rektangel = new Rectangel(5, 10);
                shapes.Add(parallelogram);
                shapes.Add(trapez);
                shapes.Add(right_triangle);
                shapes.Add(square);
                shapes.Add(rektangel);
            }
            //Here i catch potential exceptions like the one in my triangle, where i check if it meets the 180 sum degree requirement,
            //or if it exceeds it aka it's not classified as a triangle
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            //This foreach loop, loops through the list "shapes"
            foreach (Shapes shape in shapes)
            {
                //This checks if it's EShapeType is square or not.
                if (shape.Shape == EShapeType.square)
                {
                    //This switch statement is made on every type in the Enum "ESquareType" which means 
                    //now if we add more squares of different types, they will always be listed with the right dimensions etc
                    ESquareType temp_square = ((Square)shape).Squaretype;
                    switch (temp_square)
                    {
                        case ESquareType.none:
                            Console.WriteLine("This isn't a square!");
                            break;
                        case ESquareType.square:
                            Square square_cast = ((Square)shape);
                            Console.WriteLine("This is a Square!");
                            Console.WriteLine($"This squares dimensions are!\nA={square_cast.Side_a}cm");
                            Console.WriteLine($"This squares area is = {square_cast.SquareArea()}");
                            Console.WriteLine($"This squares perimiter is = {square_cast.SquarePerimeter()}\n");
                            break;
                        case ESquareType.rectangle:
                            Rectangel Rectangle_cast = ((Rectangel)shape);
                            Console.WriteLine("This is a rectangle!");
                            Console.WriteLine($"This rectangles dimensions are!\nA={Rectangle_cast.Side_a}cm\nB={Rectangle_cast.Side_b}cm");
                            Console.WriteLine($"This rectangles area is = {Rectangle_cast.SquareArea()}");
                            Console.WriteLine($"This rectangles perimiter is = {Rectangle_cast.SquarePerimeter()}\n");
                            break;
                        case ESquareType.parallelogram:
                            Parallelogram parallelogram_cast = ((Parallelogram)shape);
                            Console.WriteLine("This is a parallelogram!");
                            Console.WriteLine($"This parallelogram dimensions are!\nA={parallelogram_cast.Side_a}cm\nB={parallelogram_cast.Side_b}cm\nDegrees={parallelogram_cast.Degrees}");
                            Console.WriteLine($"This parallelogram area is = {parallelogram_cast.SquareArea()}");
                            Console.WriteLine($"This parallelogram perimiter is = {parallelogram_cast.SquarePerimeter()}\n");
                            break;
                        case ESquareType.trapez:
                            Trapez trapez_cast = ((Trapez)shape);
                            Console.WriteLine("This is a trapez!");
                            Console.WriteLine($"This trapez dimensions are!\nA={trapez_cast.Side_a}cm\nC={trapez_cast.Side_c}cm\nB={trapez_cast.Side_b}\nD={trapez_cast.Side_d}");
                            Console.WriteLine($"This trapez area is = {trapez_cast.SquareArea()}");
                            Console.WriteLine($"This trapez perimiter is = {trapez_cast.SquarePerimeter()}\n");
                            break;
                        default:
                            break;
                    }

                }
                else if (shape.Shape == EShapeType.triangle)
                {
                    //This switch statement is made on every type in the Enum "ETriangleType" which means 
                    //now if we add more Triangle of different types, they will always be listed with the right dimensions etc
                    Triangle triangle_cast = ((Triangle)shape);
                    ETriangleType temp_triangle = ((Triangle)shape).TriangleType;
                    switch (temp_triangle)
                    {
                        case ETriangleType.None:
                            Console.WriteLine("This isn't a triangle!");
                            break;
                        case ETriangleType.Right:
                            Console.WriteLine("This is a right angled triangle!");
                            Console.WriteLine($"This right angled dimensions are!\nA={triangle_cast.Side_a}cm\nC={triangle_cast.Side_c}cm\nB={triangle_cast.Side_b}");
                            Console.WriteLine($"This right angled area is = {triangle_cast.TriangleArea()}");
                            Console.WriteLine($"This right angled perimiter is = {triangle_cast.TrianglePerimiter()}\n");
                            break;
                        case ETriangleType.Acute:
                            Console.WriteLine("This is an Acute triangle!");
                            break;
                        case ETriangleType.Obtuse:
                            Console.WriteLine("This is an Obtuse triangle!");
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.ReadLine();
        }

    }
}
