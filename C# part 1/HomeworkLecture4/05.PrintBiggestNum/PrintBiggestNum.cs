using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PrintBiggestNum
{
    class PrintBiggestNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 2 numbers");
            decimal firstNum = decimal.Parse(Console.ReadLine());
            decimal secondNum = decimal.Parse(Console.ReadLine());
            Console.WriteLine(Math.Max(firstNum, secondNum));
        }
    }
}
