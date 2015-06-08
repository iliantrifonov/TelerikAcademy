using System;
using System.Collections.Generic;


class ReadArrayRemoveToMakeSorted
{
    static void Main(string[] args)
    {
        //* Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the remaining array is sorted in increasing order. Print the remaining sorted array. Example:
    	//{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
        Console.WriteLine("Enter size of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] numArr = new int[n]; //{ 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        for (int i = 0; i < numArr.Length; i++)
        {
            numArr[i] = int.Parse(Console.ReadLine());
        }
        int bestLength = 0;
        List<int> bestResult = new List<int>();
        int maxSubsets = (int)Math.Pow(2, numArr.Length);
        for (int i = 1; i < maxSubsets; i++)
        {
            List<int> result = new List<int>();
            int length = 0;
            for (int j = 0; j <= numArr.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    result.Add(numArr[j]);
                    length++;
                }
            }
            if (AreSorted(result))
            {
                if (length > bestLength)
                {
                    bestLength = length;
                    bestResult = result;
                }
            }
        }
        foreach (var item in bestResult)
        {
            Console.Write("{0} ", item);
        }
    }

    static bool AreSorted(List<int> array) // this is a method.. please read about these if you are unsure how they work
    {
        bool isSorted = true;
        for (int i = 0; i < array.Count - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                isSorted = false;
            }
        }
        return isSorted;
    }
}

