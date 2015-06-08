using System;


class Read2ArrAndCompare
{
    static void Main(string[] args)
    {
        //Write a program that reads two arrays from the console and compares them element by element.
        Console.WriteLine("Enter lenght of the first array:");
        int firstArrLenght = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the first array:");
        int[] firstArr = new int[firstArrLenght];
        for (int i = 0; i < firstArr.Length; i++)
        {
            firstArr[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter lenght of the second array:");
        int secondArrLenght = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second array:");
        int[] secondArr = new int[secondArrLenght];
        for (int i = 0; i < secondArr.Length; i++)
        {
            secondArr[i] = int.Parse(Console.ReadLine());
        }
        int compareSize = 0;
        if (firstArr.Length >= secondArr.Length)
        {
            compareSize = secondArr.Length;
        }
        else
        {
            compareSize = firstArr.Length;
        }
            
        for (int i = 0; i < compareSize; i++)
        {
            if (firstArr[i] == secondArr[i])
            {
                if (i == compareSize - 1)
                {
                    if (firstArr.Length == secondArr.Length)
                    {
                        Console.WriteLine("Arrays are equal");
                    }
                    else if (compareSize == firstArr.Length)
                    {
                        Console.WriteLine("First array is before the second array");
                    }
                    else
                    {
                        Console.WriteLine("Second array is before the first array");
                    }
                }
                continue; 
            }
            else if (firstArr[i] > secondArr[i])
            {
                Console.WriteLine("Second array is before the first array");
                break;
            }
            else
            {
                Console.WriteLine("First array is before the second array");
                break;
            }
        }
    }
}

