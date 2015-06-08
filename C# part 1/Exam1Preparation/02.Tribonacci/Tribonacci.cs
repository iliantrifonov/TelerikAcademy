using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.Tribonacci
{
    class Tribonacci
    {
        static void Main(string[] args)
        {
            BigInteger firstElem = BigInteger.Parse(Console.ReadLine());
            BigInteger secondElem = BigInteger.Parse(Console.ReadLine());
            BigInteger thirdElem = BigInteger.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            BigInteger result = 0;
            if (n == 1)
            {
                result = firstElem;
            }
            if (n == 2)
            {
                result = secondElem;
            }
            if (n == 3)
            {
                result = thirdElem;
            }
            n -= 3;
            for (int i = 0; i < n; i++)
            {
                result = firstElem + secondElem + thirdElem;
                firstElem = secondElem;
                secondElem = thirdElem;
                thirdElem = result;
            }
            Console.WriteLine(result);
        }
    }
}
