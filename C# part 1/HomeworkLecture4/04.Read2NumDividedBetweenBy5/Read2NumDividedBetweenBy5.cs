using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Read2NumDividedBetweenBy5
{
    class Read2NumDividedBetweenBy5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 2 positive integer numbers, first one must be bigger than the second");
            uint firstNum = uint.Parse(Console.ReadLine());
            uint secondNum = uint.Parse(Console.ReadLine());
            int counter = 0;
            for (uint i = firstNum; i <= secondNum; i++)
            {
                if (i % 5 == 0)
                {
                    counter++; 
                }
            }
            Console.WriteLine("p({0}, {1}) = {2}", firstNum, secondNum, counter);
        }
    }
}
