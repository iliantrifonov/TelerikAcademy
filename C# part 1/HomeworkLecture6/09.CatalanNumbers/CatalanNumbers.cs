using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            //This is a "short" more optimized formula. There are catalan calcs you can find on google that will test it
            Console.WriteLine("Catalan");
            Console.WriteLine("Enter N");
            // I'm using INT so this will not work for large numbers , can be "fixed" with BigInteger
            int n = int.Parse(Console.ReadLine());
            int doubleN = n * 2;
            int dN = n + 2;
            int sum1 = 1;
            int sum2 = 1;
            for (int i = dN; i <= doubleN; i++)
            {
                sum1 *= i;
            }
            for (int i = 1; i <= n; i++)
            {
                sum2 *= i;
            }
            Console.WriteLine(sum1 / sum2);
        }
    }
}
