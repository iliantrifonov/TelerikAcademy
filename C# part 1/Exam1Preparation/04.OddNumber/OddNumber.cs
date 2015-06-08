using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OddNumber
{
    class OddNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long firstNumber = long.Parse(Console.ReadLine());
            for (int i = 0; i < n - 1; i++)
            {
                long number = long.Parse(Console.ReadLine());
                firstNumber ^= number;
            }
            Console.WriteLine(firstNumber);
        }
    }
}
