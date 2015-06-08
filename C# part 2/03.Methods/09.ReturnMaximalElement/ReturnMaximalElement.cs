using System;

namespace _09.ReturnMaximalElement
{
    class ReturnMaximalElement
    {
        //Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.

        static void Main(string[] args)
        {
            Console.WriteLine("Enter lenght of the array:");
            int lenght = int.Parse(Console.ReadLine());
            int[] numberArray = new int[lenght];
            Console.WriteLine("Enter members of the integer array:");
            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Descending sorted array:");
            SortArrayDescending(numberArray);
            PrintArray(numberArray);
            Console.WriteLine("Ascending sorted array:");
            SortArrayAcsending(numberArray);
            PrintArray(numberArray);
        }

        private static int ReturnMax(int[] array, int startIndex, out int index)
        {
            int maxElement = array[startIndex];
            index = startIndex;
            for (int i = startIndex + 1; i < array.Length; i++)
            {
                if (array[i] > maxElement)
                {
                    index = i;
                    maxElement = array[i];
                }
            }
            return maxElement;
        }

        private static void SortArrayDescending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int index;
                int max = ReturnMax(array, i, out index);
                //swap
                int swapNum = array[i];
                array[i] = max;
                array[index] = swapNum;
            }
        }

        private static void SortArrayAcsending(int[] array)
        {
            SortArrayDescending(array);
            Array.Reverse(array);
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
