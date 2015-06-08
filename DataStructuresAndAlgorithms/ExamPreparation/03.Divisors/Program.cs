namespace _03.Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/208
    /// </summary>
    public class Program
    {
        public static int MinFactor = int.MaxValue;
        public static void Main(string[] args)
        {
            int amountOfNumbers = int.Parse(Console.ReadLine());

            var numbers = new List<string>();
            for (int i = 0; i < amountOfNumbers; i++)
            {
                var currentNumber = Console.ReadLine();
                numbers.Add(currentNumber);
            }

            var arr = numbers;

            var permutations = Algorithms.GeneratePermutations(arr);
            var hash = new SortedSet<int>();
            foreach (var p in permutations)
            {
                hash.Add(int.Parse(string.Join("", p)));
            }

            int currentMin = 0;
            foreach (var number in hash)
            {
                var currentFactor = GetFactorCount(number);

                if (currentFactor >= MinFactor)
                {
                    continue;
                }

                MinFactor = currentFactor;
                currentMin = number;
            }

            Console.WriteLine(currentMin);
        }

        public static int GetFactorCount(int numberToCheck)
        {
            int factorCount = 0;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(numberToCheck));

            // Start from 1 as we want our method to also work when numberToCheck is 0 or 1.
            for (int i = 1; i < sqrt; i++)
            {
                if (numberToCheck % i == 0)
                {
                    factorCount += 2; //  We found a pair of factors.
                    if (factorCount >= MinFactor)
                    {
                        return int.MaxValue;
                    }
                }
            }

            // Check if our number is an exact square.
            if (sqrt * sqrt == numberToCheck)
            {
                factorCount++;
            }

            return factorCount;
        }
    }
}
