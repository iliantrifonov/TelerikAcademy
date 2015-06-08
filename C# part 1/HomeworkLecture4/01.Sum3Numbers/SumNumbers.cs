using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum3Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will sum the next 3 numbers you enter");
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            Console.WriteLine("The sum is {0}", firstNum + secondNum + thirdNum);
        }
    }
}
