using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TelerikLogo
{
    class TelerikLogo
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());

            int width = (x + x) + ((x / 2 + 1) * 2) - 3;
            int hornLenght = x / 2;
            int midWidth = width - (hornLenght * 2);

            for (int i = 0; i < width; i++)
            {
                if (i == x / 2 || i == width - 1 - (x / 2))
                {
                    Console.Write("*"); 
                }
                else
                {
                    Console.Write("."); 
                }
            }
            Console.WriteLine();

            for (int i = 1; i < x - 1; i++)
            {
                for (int k = 0; k < hornLenght; k++)
                {
                    if (k == hornLenght - i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                for (int k = 0; k < midWidth; k++)
                {
                    if (k ==  i || k == (midWidth) - 1 - i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                for (int k = hornLenght; k > 0; k--)
                {
                    if (k == hornLenght + 1 - i)
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
            for (int z = 0; z < width; z++)
            {
                if (z == width / 2)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            int rows = (x * 2) - 3;
            for (int i = 0; i <= rows / 2; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    if (k == width /2 - i - 1 || k == width / 2 + i + 1)
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
            for (int i = rows / 2 - 1; i >= 0; i--)
            {
                for (int k = 0; k < width; k++)
                {
                    if (k == width / 2 - i - 1 || k == width / 2 + i + 1)
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
            for (int z = 0; z < width; z++)
            {
                if (z == width / 2)
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
