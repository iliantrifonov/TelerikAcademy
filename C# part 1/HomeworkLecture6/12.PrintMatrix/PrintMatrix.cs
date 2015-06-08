using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PrintMatrix
{
    class PrintMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int k = i; k < i+n; k++)
                {
                    Console.Write("{0,4}", k);
                }
                Console.WriteLine();
            }
        }
    }
}
