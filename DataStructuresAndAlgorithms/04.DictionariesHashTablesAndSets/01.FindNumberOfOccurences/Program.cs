namespace _01.FindNumberOfOccurences
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var numberOccurences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numberOccurences.ContainsKey(number))
                {
                    numberOccurences.Add(number, 0);
                }

                numberOccurences[number]++;
            }

            foreach (var occurencePairs in numberOccurences)
            {
                Console.WriteLine("{0} -> {1} times", occurencePairs.Key, occurencePairs.Value);
            }
        }
    }
}
