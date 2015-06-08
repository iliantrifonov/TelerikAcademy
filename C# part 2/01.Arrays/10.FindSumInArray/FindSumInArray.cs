using System;


class FindSumInArray
{
    static void Main(string[] args)
    {
        //Write a program that finds in given array of integers a sequence of given sum S (if present). 
        //Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	

        Console.WriteLine("Enter lenght of the array");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter desired sum");
        int s = int.Parse(Console.ReadLine());
        int[] numArr = new int[n];
        Console.WriteLine("Enter array elements");
        for (int i = 0; i < numArr.Length; i++)
        {
            numArr[i] = int.Parse(Console.ReadLine());
        }
        // this will only show the first sequence it encounters, and ignore all else
        for (int i = 0; i < numArr.Length; i++)
        {
            bool isFinished = false;
            int currentSum = 0;
            string currentElements = "";
            for (int k = i; k < numArr.Length; k++)
            {
                currentSum += numArr[k];
                currentElements += numArr[k] + " ";
                if (currentSum == s)
                {
                    Console.WriteLine(currentElements);
                    isFinished = true;
                    break;
                }
            }
            if (isFinished)
            {
                break;
            }
        }
    }
}

