using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TribonacciTriangle
{
    class TribonacciTriangle
    {
        static void Main(string[] args)
        {
            long firstNum = long.Parse(Console.ReadLine());
            long secondNum = long.Parse(Console.ReadLine());
            long thirdNum = long.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            Console.WriteLine(firstNum);
            Console.WriteLine(secondNum + " " + thirdNum);
            for (int i = 3; i <= lines ; i++)
            {
                for (int i2 = 1; i2 <= i; i2++)
                {
                    long lastNum = firstNum + secondNum + thirdNum;
                    Console.Write(lastNum);
                    Console.Write(" ");
                    firstNum = secondNum;
                    secondNum = thirdNum;
                    thirdNum = lastNum;
                }
                Console.WriteLine();
            }
        }
    }
}
