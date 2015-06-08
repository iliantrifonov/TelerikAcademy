using System;


class Variations
{
    static void Main(string[] args)
    {
        //Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
	    //N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
        Console.WriteLine("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        int[] numArr = new int[k];
        Variation(numArr, 0, n);
    }

    static void Variation(int[] array, int index, int n, int startIndex = 1)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = startIndex; i <= n; i++)
            {
                array[index] = i;
                Variation(array, index + 1, n, i + 1);
            }
        }
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

