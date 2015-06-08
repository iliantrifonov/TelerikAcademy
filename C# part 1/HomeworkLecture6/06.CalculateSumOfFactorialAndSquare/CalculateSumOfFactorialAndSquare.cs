using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _06.CalculateSumOfFactorialAndSquare
{
    class CalculateSumOfFactorialAndSquare
    {
        static void Main(string[] args)
        {
            Console.WriteLine("X and N are positive integers");
            Console.WriteLine("Please enter X:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter N:");
            int n = int.Parse(Console.ReadLine());
            BigInteger curFactorial;
            BigInteger curPower;
            BigInteger result = 1; // this will work slowly, but it will work
            for (int i = 1; i <= n; i++)
            {
                curPower = 1;
                curFactorial = 1;
                for (int counterFactorial = 1; counterFactorial <= i; counterFactorial++)
                {
                    curFactorial *= counterFactorial;  
                }
                for (int counterPower = 1; counterPower <= i; counterPower++)
                {
                    curPower *= x;
                }
                result += (curFactorial / curPower);
            }
            Console.WriteLine(result);
        }
    }
}
