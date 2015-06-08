using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fire
{
    class Fire
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n / 2; i++)
            {
                for (int i2 = 0; i2 < n; i2++)
                {
                    if (i2 == n / 2 - i - 1 || i2 == n / 2 + i)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < n / 4; i++)
            {
                for (int i2 = 0; i2 < n; i2++)
                {
                    if (i2 == i || i2 == n - i - 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for (int i = 0; i < n / 2; i++)
            {
                for (int i2 = 0; i2 < n; i2++)
                {
                    if (i2 >= i && i2 <= n / 2 - 1)
                    {
                        Console.Write(@"\");
                    }
                    else if (i2 > n / 2 - 1 && i2 <= n - i - 1)
                    {
                        Console.Write("/");
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
