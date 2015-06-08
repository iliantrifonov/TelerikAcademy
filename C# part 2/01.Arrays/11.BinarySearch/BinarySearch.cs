using System;


class BinarySearch
{
    static void Main(string[] args)
    {
        //Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

        int[] numArr = { 1, 2, 3, 3, 5 };//{ 1, 2, 3, 4, 8, 10, 12, 18, 71, 222, 557, 566, 711, 845 };
        int enteredNum = 4;
        Array.Sort(numArr);
        
        int maxLeft = 0;
        int maxRight = numArr.Length - 1;
        while (maxRight >= maxLeft)
        {
            int mid = (maxLeft + maxRight) / 2;
            if (enteredNum > numArr[mid])
            {
                maxLeft = mid + 1;
            }
            else if (enteredNum < numArr[mid])
            {
                maxRight = mid - 1;
            }
            else
            {
                Console.WriteLine("The postition is: " + mid);
                break;
            }
        }
    }
}

