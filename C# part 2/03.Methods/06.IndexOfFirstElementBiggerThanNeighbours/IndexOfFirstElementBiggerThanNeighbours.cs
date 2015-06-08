using System;

namespace _06.IndexOfFirstElementBiggerThanNeighbours
{
    //Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.

    class IndexOfFirstElementBiggerThanNeighbours
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
            Console.WriteLine("The index of the first element in array that is bigger than its neighbors is:");
            Console.WriteLine(IndexOfElementBiggerThanNeighbours(numberArray));
        }

        private static int IndexOfElementBiggerThanNeighbours(int[] array)
        {
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (IsMemberBiggerThanNeighbours(array, i))
                {
                    return i;
                }
            }
            return -1;
        }

        private static bool IsMemberBiggerThanNeighbours(int[] array, int position)
        {
            if (position == 0)
            {
                return false;
            }
            if (position == array.Length - 1)
            {
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
