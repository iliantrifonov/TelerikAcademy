using System;


class Permutations
{
    static void Main(string[] args)
    {
        //* Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. Example:
	    //n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

        Console.WriteLine("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        int[] arrayOfNumbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            arrayOfNumbers[i] = i + 1;
        }

        Permutate(arrayOfNumbers, 0, arrayOfNumbers.Length - 1);
    }

    static void Swap(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }

    static void Permutate(int[] array, int current, int length)
    {
        if (current == length)
        {
            for (int i = 0; i <= length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = current; i <= length; i++)
            {
                Swap(ref array[i], ref array[current]);
                Permutate(array, current + 1, length);
                Swap(ref array[i], ref array[current]);
            }
        }

    }
}

