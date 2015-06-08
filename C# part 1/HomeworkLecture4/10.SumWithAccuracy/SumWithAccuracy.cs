using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SumWithAccuracy
{
    class SumWithAccuracy
    {
        static void Main(string[] args)
        {
            double sum = 1d;
            double prevSum = 0d;
            for (int i = 2; i < 1000000000; i++)
            {
                sum += 1d / i;
                if (sum - prevSum <= 0.001)
                {
                    //gets me out of the cicle when this is true
                    break;
                }
                prevSum = sum;
            }
            Console.WriteLine("the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ... is {0:0.000}", sum);
        }
    }
}
