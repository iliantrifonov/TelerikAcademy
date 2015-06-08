namespace ZigZagSequences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int[] arr;
        private static bool[] used;
        private static int zigZagCount = 0;

        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = input[0];
            int k = input[1];
            arr = new int[k];
            used = new bool[n];
            GenerateVariationsNoRepetitions(0, k, n);
            Console.WriteLine(zigZagCount);
        }

        public static void GenerateVariationsNoRepetitions(int index, int k, int n)
        {
            if (index >= k)
            {
                if (IsZigZag())
                {
                    zigZagCount++;                   
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1, k, n);
                        used[i] = false;
                    }
                }
            }
        }

        public static bool IsZigZag()
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (arr[i] < arr[i-1])
                    {
                        return false;
                    }
                }
                else
                {
                    if (arr[i] > arr[i - 1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void PrintVariations()
        {
            Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine(")");
        }
    }
}
