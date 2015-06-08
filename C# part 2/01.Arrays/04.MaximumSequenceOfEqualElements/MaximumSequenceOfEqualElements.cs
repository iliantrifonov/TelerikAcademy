using System;


class MaximumSequenceOfEqualElements
{
    static void Main(string[] args)
    {
        //Write a program that finds the maximal sequence of equal elements in an array.
		//Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
        int[] numArr = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int count = 0;
        int maxCount = 0;
        int prevElement = numArr[0];
        string resultConsecutiveElements = numArr[0].ToString();
        string currentConsecutiveElements = numArr[0].ToString();
        for (int i = 1; i < numArr.Length; i++)
        {
            if (numArr[i] != prevElement)
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
        Console.WriteLine(resultConsecutiveElements); // if more than once sequence has the maximal size, it will use the first, and it will print the first element if maximal sequence is 1
    }
}

