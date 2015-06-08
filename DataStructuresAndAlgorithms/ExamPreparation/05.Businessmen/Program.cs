namespace _05.Businessmen
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/433
    /// </summary>
    public class Program
    {
        public static long[] cache = new long[80];
        public static void Main(string[] args)
        {
            Console.WriteLine(SecondOption(long.Parse(Console.ReadLine()) / 2));
        }

        public static long SecondOption(long n)
        {
            if (cache[n] != 0)
            {
                return cache[n];
            }
            if (n == 0)
            {
                return 1;
            }
            long sum = 0;
            long i = 0;
            for (; i <= (n - 1); i++)
            {
                sum += SecondOption(i) * SecondOption((n - 1) - i);
            }

            cache[n] = sum;
            return sum;
        }
    }
}
