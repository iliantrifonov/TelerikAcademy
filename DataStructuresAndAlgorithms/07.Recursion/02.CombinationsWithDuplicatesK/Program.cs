namespace _02.CombinationsWithDuplicatesK
{
    using System;

    /// <summary>
    /// Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. Example:
    /// n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = 3;
            var k = 2;
            var arr = new int[k];
            PrintNumbers(0, 1, n, arr);
        }

        public static void PrintNumbers(int index, int start, int end, int[] arr)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(", ", arr));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                arr[index] = i;
                PrintNumbers(index + 1, i, end, arr);
            }
        }
    }
}
