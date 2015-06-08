namespace _05.VariationsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
    /// Example: n=3, k=2, set = {hi, a, b} =>
    /// (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
    /// </summary>
    public class Program
    {
        public static string[] setArray = new string[] { "hi", "a", "b" };
        public static string[] resultArray;

        public static void Main(string[] args)
        {
            int n = 2;
            resultArray = new string[n];

            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= resultArray.Length)
            {
                Console.WriteLine(string.Join(" ", resultArray));
                return;
            }

            for (int i = 0; i < setArray.Length; i++)
            {
                resultArray[index] = setArray[i];
                Variate(index + 1);
            }
        }
    }
}
