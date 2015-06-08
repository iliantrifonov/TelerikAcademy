namespace _04.SequenceOfColoredBalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/210
    /// </summary>
    public class Program
    {
        public static BigInteger[] Factorials;
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Factorials = new BigInteger[input.Length + 1];
            var ballsAndAmounts = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (!ballsAndAmounts.ContainsKey(currentChar))
                {
                    ballsAndAmounts.Add(currentChar, 0);
                }

                ballsAndAmounts[currentChar] += 1;
            }

            BigInteger result = Factorial(input.Length);

            BigInteger ballFactorialResult = 1;
            foreach (var ball in ballsAndAmounts.Values)
            {
                ballFactorialResult *= Factorial(ball);
            }

            result /= ballFactorialResult;
            Console.WriteLine(result);
        }

        private static BigInteger Factorial(int n)
        {

            if (Factorials[n] != 0)
            {
                return Factorials[n];
            }

            if (n <= 1)
            {
                return 1;
            }

            var result = n * Factorial(n - 1);
            Factorials[n] = result;

            return result;
        }
    }
}
