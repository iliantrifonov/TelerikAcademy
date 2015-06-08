using System;

namespace _05.IsMemberBiggerThanTwoNeighbours
{
    //Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

    class MemberBiggerThanTwoNeighbours
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
            Console.WriteLine("Enter the position of the number you would like to check for:");
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine(IsMemberBiggerThanNeighbours(numberArray, position));
        }

        private static bool IsMemberBiggerThanNeighbours(int[] array, int position)
        {
            if (position == 0)
            {
                Console.WriteLine("Two neightbour members do not exist"); //it is not a good idea to do this, but I'd rather not throw exceptions and catch them in the main method
                return false;
            }
            if (position == array.Length - 1)
            {
                Console.WriteLine("Two neightbour members do not exist"); //it is not a good idea to do this, but I'd rather not throw exceptions and catch them in the main method
                return false;
            }

            if (array[position] > array[position - 1] && array[position] > array[position + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
