using System;


class SubsetSumOfKElementsWithSSum
{
    static void Main(string[] args)
    {
        //* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. Find in the array a subset of K elements that have sum S or indicate about its absence.
        Console.WriteLine("Enter N");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter K");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter S");
        int s = int.Parse(Console.ReadLine());
        int finalSum = int.MinValue;
        int[] numberArray = new int[n];
        for (int i = 0; i < numberArray.Length; i++)
        {
            numberArray[i] = int.Parse(Console.ReadLine());
        }

        int counterOfNumbers = 0;
        for (int i = 1; i <= Math.Pow(2, numberArray.Length) - 1; i++)
        {
            string stringNumbers = ""; //Yes I know I can use a stringbuilder:P
            int currentSum = 0;
            counterOfNumbers = 0;
            for (int z = 0; z < numberArray.Length; z++)
            {
                if (((i >> z) & 1) == 1)
                {
                    currentSum += numberArray[z];
                    stringNumbers += numberArray[z] + " ";
                    counterOfNumbers++;
                }
            }
            if (currentSum == s && counterOfNumbers == k)
            {
                Console.WriteLine("{1} = {0}", currentSum, stringNumbers); // if we just break here we will just find 1 sum
                finalSum = currentSum;
            }
        }
        if (finalSum != s && counterOfNumbers != k)
        {
            Console.WriteLine("No");
        }
    }
}

