using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.UKflag
{
    class UKflag
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n / 2;

            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (k == n /2)
                    {
                        Console.Write("|");
                    }
                    else if (k == i)
                    {
                        Console.Write("\\");
                    }
                    else if (k == n - 1 - i)
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
            for (int i = 0; i < n; i++)
            {
                if (i == n /2)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (k == n / 2)
                    {
                        Console.Write("|");
                    }
                    else if (k == (n /2) + 1 + i)
                    {
                        Console.Write("\\");
                    }
                    else if (k == (n / 2) - 1 - i)
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
