using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CirclePerimAndArea
{
    class CirclePerimAndArea
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter radius of a circle");
            int radius = int.Parse(Console.ReadLine());
            Console.WriteLine("Perimeter of the circle is {0}, and the area is {1}", 2 * Math.PI * radius, Math.PI * radius * radius);
        }
    }
}
