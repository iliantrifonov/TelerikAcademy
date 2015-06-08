using System;


class ArrayOf20Integers
{
    static void Main(string[] args)
    {
        //Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.
        int[] numArr = new int[20];
        for (int i = 0; i < numArr.Length; i++)
        {
            numArr[i] = i * 5;
        }
        foreach (var item in numArr)
        {
            Console.WriteLine(item);
        }
    }
}

