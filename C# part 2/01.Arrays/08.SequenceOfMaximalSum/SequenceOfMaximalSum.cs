using System;
using System.Text;


class SequenceOfMaximalSum
{
    static void Main(string[] args)
    {
        //Write a program that finds the sequence of maximal sum in given array. Example:
	    //{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	    //Can you do it with only one loop (with single scan through the elements of the array)?

        int[] numArr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int currentSum = 0;
        int maxSum = int.MinValue;
        StringBuilder maxSequenceBuild = new StringBuilder();
        string maxSequnce = "";
        for (int i = 0; i < numArr.Length; i++)
        {
            currentSum = currentSum + numArr[i];
            maxSequenceBuild.AppendFormat("{0}, ", numArr[i]);
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxSequnce = maxSequenceBuild.ToString();
            }
            if (currentSum < 0)
            {
                currentSum = 0;
                maxSequenceBuild.Clear();
            }
        }
        Console.WriteLine("The sequence is: {0}", maxSequnce);
        Console.WriteLine("The maximum sum is: {0} ", maxSum);
    }
}

