using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.IsPointInCircleOutOfRectangle
{
    class CheckPoint
    {
        static void Main(string[] args)
        {
            int pointX = 2;
            int pointY = 2;
            // since center of the circle is 1,1 I just move the points in a way that the center of the circle is the center of the coordinate system. I will do the same for the rectangle
            pointX -= 1;
            pointY -= 1;
            int recTop = 1;
            int recLeft = -1;
            recTop -= 1;
            recLeft -= 1;
            double r = 3;
            //r = double.Parse(Console.ReadLine()); // This is if you do not want to fix the radius
            Console.WriteLine(((pointX * pointX) + (pointY * pointY) <= (r * r)) && (((pointX < recLeft) || (pointX > (recLeft + 6))) || ((pointY > recTop) || (pointY < (recTop - 2)))) ? "Yes" : "No"); // Pythagoras theorem + checks if its inside the square 
        }
    }
}
