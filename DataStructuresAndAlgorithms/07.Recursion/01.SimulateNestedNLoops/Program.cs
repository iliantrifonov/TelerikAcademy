namespace _01.SimulateNestedNLoops
{
    using System;

    /// <summary>
    /// Write a recursive program that simulates the execution of n nested loops from 1 to n. 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = 3;
            var arr = new int[n];
            PrintNumbers(n, arr);
        }

        public static void PrintNumbers(int n, int[] arr)
        {
            if (n <= 0)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[arr.Length - n] = i;
                PrintNumbers(n - 1, arr);
            }
        }
    }
}
