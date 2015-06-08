namespace _06.SubsetOfStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program for generating and printing all subsets of k strings from given set of strings.
    /// Example: s = {test, rock, fun}, k=2
    /// (test rock),  (test fun),  (rock fun)
    /// </summary>
    public class Program
    {
        private static string[] setArray = new string[] { "test", "rock", "fun" };
        private static string[] resultArray;

        public static void Main(string[] args)
        {
            int n = 2;
            resultArray = new string[n];

            PrintSubsets(0, 0);
        }

        private static void PrintSubsets(int index, int start)
        {
            if (index >= resultArray.Length)
            {
                Console.WriteLine(string.Join(" ", resultArray));
                return;
            }

            for (int i = start; i < setArray.Length; i++)
            {
                resultArray[index] = setArray[i];
                PrintSubsets(index + 1, i + 1);
            }
        }
    }
}
