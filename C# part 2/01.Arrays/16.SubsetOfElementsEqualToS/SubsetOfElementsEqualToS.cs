using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SubsetOfElementsEqualToS
{
    static void Main(string[] args)
    {
        //* We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
    	//arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
        
        //Console.WriteLine("enter N");
        //int n = int.Parse(Console.ReadLine());
        //Console.WriteLine("enter sum");
        int s = 14; //int.Parse(Console.ReadLine());
        int finalSum = int.MinValue;
        int[] numberArray = { 2, 1, 2, 4, 3, 5, 2, 6 };// new int[n];
        //for (int i = 0; i < numberArray.Length; i++)
        //{
        //    numberArray[i] = int.Parse(Console.ReadLine());
        //}
        for (int i = 1; i <= Math.Pow(2, numberArray.Length) - 1; i++)
        {
            string stringNumbers = ""; //Yes I know I can use a stringbuilder:P
            int currentSum = 0;
            for (int j = 0; j < numberArray.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    currentSum += numberArray[j];
                    stringNumbers += numberArray[j] + " ";
                }
            }
            if (currentSum == s)
            {
                Console.WriteLine("{1} = {0}", currentSum, stringNumbers); // if we just break here we will just find 1 sum
                finalSum = currentSum;
            }
        }
        if (finalSum != s)
        {
            Console.WriteLine("No");
        }
    }
}

