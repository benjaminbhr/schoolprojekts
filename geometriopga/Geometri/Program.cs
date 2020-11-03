using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape square = new Square(10);
            Shape parallelogram = new Parallelogram(5, 10, 20);
            Shape trapezoid = new Trapezoid(20, 10, 7);
            Shape rightangledtriangle = new RightAngledTriangle(10, 20);
            Shape rectangle = new Rectangle(20, 10);
            List<Shape> shapes = new List<Shape>();
            shapes.Add(square);
            shapes.Add(parallelogram);
            shapes.Add(trapezoid);
            shapes.Add(rightangledtriangle);
            shapes.Add(rectangle);
            foreach (var shape in shapes)
            {
                switch (shape.GetType().Name)
                {
                    case "Square":
                        var squareCast = ((Square)shape);
                        Console.WriteLine("This is a square!");
                        Console.WriteLine($"This Square's area is = {shape.Area()}cm2");
                        Console.WriteLine($"This Square's Perimeter is = {shape.Perimeter()}cm\n");
                        break;
                    case "Rectangle":
                        var rectangleCast = ((Rectangle)shape);
                        Console.WriteLine("This is a Rectangle!");
                        Console.WriteLine($"This Rectangle's area is = {shape.Area()}cm2");
                        Console.WriteLine($"This Rectangle's Perimeter is = {shape.Perimeter()}cm\n");
                        break;
                    case "Parallelogram":
                        var parallelCast = ((Parallelogram)shape);
                        Console.WriteLine("This is a Parallelogram!");
                        Console.WriteLine($"This Parallelogram's area is = {shape.Area()}cm2");
                        Console.WriteLine($"This Parallelogram's Perimeter is = {shape.Perimeter()}cm\n");
                        break;
                    case "Trapezoid":
                        var trapezCast = ((Trapezoid)shape);
                        Console.WriteLine("This is a Trapezoid");
                        Console.WriteLine($"This Trapezoid's area is = {shape.Area()}cm2");
                        Console.WriteLine($"This Trapezoid's perimeter is = {shape.Perimeter()}cm\n");
                        break;
                    case "RightAngledTriangle":
                        var rightangleCast = ((RightAngledTriangle)shape);
                        Console.WriteLine("This is a Right Angled Triangle!");
                        Console.WriteLine($"This Triangle's area is = {shape.Area()}cm2");
                        Console.WriteLine($"This Triangle's perimeter is = {shape.Perimeter()}cm\n");
                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
