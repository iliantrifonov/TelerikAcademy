using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _13.CalculateZerosInFactorial
{
    class CalculateZerosInFactorial
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many 0 at the end of a factorial with N, enter N");
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            BigInteger c = 0;
            int numberOfZeros = 0;
            for (int j = 1; j <= n; j++)
            {
                factorial *= j;
            }
            while (c == 0)
            {
                c = factorial % 10;
                factorial = factorial / 10;
                if (c != 0)
                {
                    break;
                }
                numberOfZeros++;
            }
            Console.WriteLine(numberOfZeros);
        }
    }
}
