using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.IsPointInCircle
{
    class IsPointInCircle
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculating if a point O with coordinates (x,y) is within a circle with a radius R");
            Console.WriteLine("Please enter x");
            double a;
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter y");
            double b;
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter r");
            double r = 5;
            //r = double.Parse(Console.ReadLine()); // This is if you do not want to fix the radius
            Console.WriteLine((a * a) + (b * b) <= (r * r) ? "Yes" : "No"); // Pythagoras theorem
        }
    }
}
