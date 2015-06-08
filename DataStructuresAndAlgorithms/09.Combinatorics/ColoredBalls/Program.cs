namespace ColoredBalls
{
    using System;
    using System.Linq;

    /// <summary>
    /// downloads.academy.telerik.com/svn/algo-academy/2012-10-Combinatorics/All%20problems/Problem%202.zip
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] balls = input.ToCharArray();

            long sequenceCount = CountSequencesFast(balls);
            Console.WriteLine(sequenceCount);
        }

        private static void AddDivisors(int count, int[] denominators)
        {
            int divisor = 2;

            while (count > 1)
            {
                if (count % divisor == 0)
                {
                    denominators[divisor]++;
                    count = count / divisor;
                }
                else
                {
                    divisor++;
                }
            }
        }

        private static long CountSequencesFast(char[] balls)
        {
            int length = balls.Length;

            int[] numerators = new int[length + 1];

            for (int i = 2; i <= length; i++)
            {
                AddDivisors(i, numerators);
            }

            int[] ballCounts = new int['Z' + 1];

            foreach (var ball in balls)
            {
                ballCounts[ball]++;
            }

            int[] denominators = new int[length + 1];

            for (int i = 'A'; i <= 'Z'; i++)
            {
                int ballsOfCertainColor = ballCounts[i];

                for (int count = 2; count <= ballsOfCertainColor; count++)
                {
                    AddDivisors(count, denominators);
                }
            }

            long result = 1;

            for (int divisor = 2; divisor <= length; divisor++)
            {
                int count = numerators[divisor] - denominators[divisor];
                for (int i = 0; i < count; i++)
                {
                    result *= divisor;
                }
            }

            return result;
        }
    }
}