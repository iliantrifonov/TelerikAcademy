using System;
using System.Collections.Generic;


class MergeSort
{
    static void Main()
    {
        //* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

        List<int> someArray = new List<int> { 235, 41, 5, 6, 8, 4, 6, 99, 71, 2, 557, 56, 7, 45 };
        List<int> sortedArr = MyMergeSort(someArray);
        foreach (int element in sortedArr)
        {
            Console.Write("{0,-4}", element);
        }
        Console.WriteLine();
    }

    static List<int> MyMergeSort(List<int> unsortedList ) // this is a method, if you do not understand, please skip ahead and read about how methods work
    {
        if (unsortedList.Count <= 1)
        {
            return unsortedList; //this is what gets returned to get "merged" later when recursion is called, and also if there is only 1 element in the array originally, it returns it
        }
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        int mid = unsortedList.Count / 2;
        for (int i = 0; i < mid; i++)
        {
            left.Add(unsortedList[i]);
        }
        for (int i = mid; i < unsortedList.Count; i++)
        {
            right.Add(unsortedList[i]);
        }
        left = MyMergeSort(left); //this is recursion.. please read about recursion if you do not understand, here it basically goes ahead and splits all elements until it gets to a single element, it just keeps calling itself
        right = MyMergeSort(right);
        return Merge(left, right); // this returns the result
    }

    static List<int> Merge(List<int> left, List<int> right ) //this method "merges" back the elements that were split before, and returns a List<int>
    {
        List<int> result = new List<int>();
        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        return result;
    }
}


