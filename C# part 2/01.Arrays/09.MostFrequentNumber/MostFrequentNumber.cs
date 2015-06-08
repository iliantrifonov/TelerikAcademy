
using System;

class MostFrequentNumber
{
    static void Main(string[] args)
    {
        //Write a program that finds the most frequent number in an array. Example:
	    //{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
        int[] numArr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        Array.Sort(numArr);
        int prevNumber = numArr[0];
        int number = 0;
        int count = 1;
        int maxCounter = 0;
        for (int i = 1; i < numArr.Length; i++)
        {
            if (numArr[i] != prevNumber)
            {
                if (count > maxCounter)
                {
                    maxCounter = count;
                    number = prevNumber;
                }

                count = 1;
            }
            else
            {
                count++;
            }
            prevNumber = numArr[i];
        }
        Console.WriteLine("{0} ({1} times)", number, maxCounter);
    }
}

