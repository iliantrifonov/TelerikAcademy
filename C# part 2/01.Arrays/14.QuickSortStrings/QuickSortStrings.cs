using System;
using System.Collections.Generic;


class QuickSortStrings
{

    static List<string> QuickSort(List<string> listOfStrings)
    {
        if (listOfStrings.Count <= 1)
        {
            return listOfStrings;
        }
 
        string pivot = listOfStrings[listOfStrings.Count / 2];
        List<string> left = new List<string>();
        List<string> right = new List<string>();
 
        for (int i = 0; i < listOfStrings.Count; i++)
        {
            if (i != (listOfStrings.Count / 2))
            {
                string str = listOfStrings[i];
                int compareStringsNumber = string.Compare(str, pivot);
                if (compareStringsNumber == 1) //you can reverse the sorting, if you put -1 here
                {
                    right.Add(listOfStrings[i]);
                }
                else
                {
                    left.Add(listOfStrings[i]);
                }
            }
        }
        List<string> result = new List<string>();
           
        result.AddRange(QuickSort(left));// recursion, please read about it
        result.Add(pivot);
        result.AddRange(QuickSort(right));
 
        return result;
    }
 
    static void Main()
    {
        Console.WriteLine("Enter amount of strings in array: ");
        int n = int.Parse(Console.ReadLine());
        List<string> strList = new List<string>();
        Console.WriteLine("Enter strings: ");
        for (int index = 0; index < n; index++)
        {
            strList.Add(Console.ReadLine());
        }
        List<string> sortedList = QuickSort(strList);
        Console.WriteLine();
        foreach (string item in sortedList)
        {
            Console.WriteLine(item);
        }
    }

}

