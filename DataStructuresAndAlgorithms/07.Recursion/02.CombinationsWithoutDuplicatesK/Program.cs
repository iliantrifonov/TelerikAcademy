namespace _02.CombinationsWithoutDuplicatesK
{
    using System;

    /// <summary>
    /// Modify the previous program to skip duplicates:
    /// n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = 4;
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
                PrintNumbers(index + 1, i + 1, end, arr);
            }
        }
    }
}
