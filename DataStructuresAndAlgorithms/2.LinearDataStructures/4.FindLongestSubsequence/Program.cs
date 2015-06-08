namespace _4.FindLongestSubsequence
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>. Write a program to test whether the method works correctly.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 3, 3, 3, 4, 4, 1, 4 };
            var longestEqualSequence = GetLongestSequence(numbers);
            Console.WriteLine(string.Join(" ", longestEqualSequence));
        }

        public static IEnumerable<int> GetLongestSequence(int[] numbers)
        {
            int maxLength = 1;
            int maxIndex = 0;

            for (int currentIndex = 1, currentLength = 1; currentIndex < numbers.Length; currentIndex++)
            {
                if (numbers[currentIndex] != numbers[currentIndex - 1])
                {
                    currentLength = 0;
                }

                currentLength++;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxIndex = currentIndex - currentLength + 1;
                }
            }

            return new List<int>(numbers.Skip(maxIndex).Take(maxLength));
        }
    }
}
