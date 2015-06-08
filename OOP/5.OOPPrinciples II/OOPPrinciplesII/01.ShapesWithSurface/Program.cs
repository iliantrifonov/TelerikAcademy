namespace _01.ShapesWithSurface
{
    //Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() method. Write a program that tests the behavior of  the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array.
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Shape[] arr = new Shape[] { new Rectangle(2, 4), new Rectangle(3, 1), new Circle(3), new Circle(2), new Triangle(1, 4) };
            foreach (var shape in arr)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}