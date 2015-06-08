using System;


class SelectionSort
{
    static void Main(string[] args)
    {
        //Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
        Console.WriteLine("Enter the size of the array:");
        int arrayLenght = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter array elements for sorting");
        int[] numArr = new int[arrayLenght];
        for (int i = 0; i < numArr.Length; i++)
        {
            numArr[i] = int.Parse(Console.ReadLine());
        }
        //start sorting
        int[] resultArray = new int[numArr.Length];
        for (int i = 0; i < numArr.Length; i++)
        {
            int minNumber = int.MaxValue;
            int elementIndex = 0;
            for (int k = 0; k < numArr.Length; k++)
            {
                if (numArr[k] < minNumber)
                {
                    elementIndex = k;
                    minNumber = numArr[k];
                }
            }
            resultArray[i] = numArr[elementIndex];
            numArr[elementIndex] = int.MaxValue;
        }
        foreach (var item in resultArray)
        {
            Console.Write(item + " ");
        }
    }
}

