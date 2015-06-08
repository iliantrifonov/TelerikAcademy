using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ForestRoad
{
    class ForestRoad
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = (width * 2) - 1;
            for (int i = 0; i < width; i++)
            {
                for (int i2  = 0; i2 < width; i2++)
                {
                    if (i2 == i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            for (int i = width - 2; i >= 0; i--)
            {
                for (int i2 = 0; i2 < width; i2++)
                {
                    if (i2 == i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
