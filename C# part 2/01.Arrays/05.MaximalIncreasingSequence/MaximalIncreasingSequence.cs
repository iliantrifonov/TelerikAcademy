using System;


class MaximalIncreasingSequence
{
    static void Main(string[] args)
    {
        //Write a program that finds the maximal increasing sequence in an array.
        //Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
        int[] numArr = { 3, 2, 3, 4, 2, 2, 4 };
        int count = 0;
        int maxCount = 0;
        int prevElement = numArr[0];
        string resultConsecutiveElements = numArr[0].ToString();
        string currentConsecutiveElements = numArr[0].ToString();
        for (int i = 1; i < numArr.Length; i++)
        {
            if (numArr[i] <= prevElement)
            {
                if (count > maxCount)
                {
                    maxCount = count;
                    resultConsecutiveElements = currentConsecutiveElements;
                }
                count = 0;
                currentConsecutiveElements = numArr[i].ToString();
            }
            else
            {
                count++;
                currentConsecutiveElements += ", " + numArr[i].ToString();
            }
            prevElement = numArr[i];
        }
        Console.WriteLine(resultConsecutiveElements);
    }
}

