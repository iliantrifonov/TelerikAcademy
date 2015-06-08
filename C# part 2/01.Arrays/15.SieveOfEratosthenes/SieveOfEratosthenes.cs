using System;


class SieveOfEratosthenes
{
    static void Main(string[] args)
    {
        //Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
        int[] allNumbersArray = new int[10000001];
        for (int i = 1; i < allNumbersArray.Length; i++)
        {
            allNumbersArray[i] = i;
        }
        allNumbersArray[0] = int.MinValue;
        allNumbersArray[1] = int.MinValue;
        for (int i = 2; i < allNumbersArray.Length; i++)
        {
            if (allNumbersArray[i] == int.MinValue)
            {
                continue;
            }
            int counter = 2;
            while (i * counter < allNumbersArray.Length)
            {
                allNumbersArray[i * counter] = int.MinValue;
                counter++;
            }
        }
        for (int i = 2; i < allNumbersArray.Length; i++)
        {
            if (allNumbersArray[i] != int.MinValue)
            {
                Console.Write(allNumbersArray[i] + ", ");
            }
        }
    }
}

