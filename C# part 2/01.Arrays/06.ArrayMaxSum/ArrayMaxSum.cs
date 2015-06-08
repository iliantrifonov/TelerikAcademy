using System;


class ArrayMaxSum
{
    static void Main(string[] args)
    {
        //Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.
        Console.WriteLine("Enter N:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter K:");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter array of N elements:");
        int[] numArr = new int[n];
        for (int i = 0; i < numArr.Length; i++)
        {
            numArr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(numArr);
        if (numArr.Length < k)
        {
            Console.WriteLine("K cannot be smaller than N");
        }
        else
        {
            for (int i = numArr.Length - k; i < numArr.Length; i++)
            {
                Console.Write(numArr[i] + " ");
            }
        }
    }
}

