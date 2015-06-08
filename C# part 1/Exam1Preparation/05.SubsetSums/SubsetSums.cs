using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SubsetSums
{
    class SubsetSums
    {
        static void Main(string[] args)
        {
            long s = long.Parse(Console.ReadLine());
            long n = long.Parse(Console.ReadLine());
            long[] arr = new long[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                arr[i] = long.Parse(Console.ReadLine());
            }
            for (long i = 1; i <= Math.Pow(2, n) - 1; i++)
            {
                long sum = 0;
                for (int k = 0; k < n; k++)
                {
                    if (((i >> k) & 1) == 1)
                    {
                        sum += arr[k];
                    }
                }
                if (sum == s)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
