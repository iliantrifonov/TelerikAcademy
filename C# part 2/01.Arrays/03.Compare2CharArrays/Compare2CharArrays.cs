using System;


class Compare2CharArrays
{
    static void Main(string[] args)
    {
        //Write a program that compares two char arrays lexicographically (letter by letter).
        Console.WriteLine("Enter lenght of the first array:");
        int firstArrLenght = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the first array:");
        char[] firstArr = new char[firstArrLenght];
        for (int i = 0; i < firstArr.Length; i++)
        {
            firstArr[i] = char.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter lenght of the second array:");
        int secondArrLenght = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second array:");
        char[] secondArr = new char[secondArrLenght];
        for (int i = 0; i < secondArr.Length; i++)
        {
            secondArr[i] = char.Parse(Console.ReadLine());
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

