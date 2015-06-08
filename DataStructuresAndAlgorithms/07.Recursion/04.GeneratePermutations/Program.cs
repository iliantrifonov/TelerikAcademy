namespace _04.GeneratePermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. Example:
    /// n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},					{2, 3, 1}, {3, 1, 2},{3, 2, 1}
    /// </summary>
    public class Program
    {
        private static int[] array;
        private static int[] checkArray;

        public static void Main(string[] args)
        {
            int n = 3;
            array = new int[n];
            checkArray = new int[n];

            Permutate(0);
        }

        private static void Permutate(int index)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = 0; i < checkArray.Length; i++)
            {
                if (checkArray[i] == 1)
                {
                    continue;
                }

                array[index] = i + 1;
                checkArray[i] = 1;
                Permutate(index + 1);
                checkArray[i] = 0;
            }
        }
    }
}
