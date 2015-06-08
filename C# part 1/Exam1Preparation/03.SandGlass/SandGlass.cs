
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SandGlass
{
    class SandGlass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n /2; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (k < i || k > n - i - 1)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
            for (int i = n / 2; i >= 0 / 2; i--)
            {
                for (int k = 0; k < n; k++)
                {
                    if (k < i || k > n - i - 1)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
