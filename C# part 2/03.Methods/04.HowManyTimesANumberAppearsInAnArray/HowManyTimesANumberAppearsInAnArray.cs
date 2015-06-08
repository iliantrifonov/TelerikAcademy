using System;

namespace _04.HowManyTimesANumberAppearsInAnArray
{
    //Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

    class HowManyTimesANumberAppearsInAnArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter lenght of the array:");
            int lenght = int.Parse(Console.ReadLine());
            int[] numberArray = new int[lenght];
            Console.WriteLine("Enter members of the integer array:");
            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter the number you would like to check count for:");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("The number {0} appears {1} times in the array", num, CountNumInArray(numberArray,num));
        }

        private static int CountNumInArray(int[] array, int number)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
			{
			    if (array[i] == number)
	            {
		            counter++;
	            }
			}
            return counter;
        }
    }
}
