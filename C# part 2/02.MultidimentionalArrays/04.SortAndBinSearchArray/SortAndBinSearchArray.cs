using System;

namespace _04.SortAndBinSearchArray
{
    class SortAndBinSearchArray
    {
        static void Main(string[] args)
        {
            //Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 
            Console.WriteLine("Enter N:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter K:");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter array:");
            int[] numberArray = new int[n];
            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numberArray);
            int indexOfResult = Array.BinarySearch(numberArray, k);
            if (indexOfResult < 0)
            {
                indexOfResult = (~indexOfResult) - 1;
            }
            if (indexOfResult >= 0)
            {
                Console.WriteLine("Number K, or the largest that is smaller than K:");
                Console.WriteLine(numberArray[indexOfResult]);
            }
            else
            {
                Console.WriteLine("No number that fits those criteria exists");
            }
        }
    }
}
