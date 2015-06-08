using System;
using System.Numerics;

namespace _14.MinMaxAvarageSumOfIntegers
{
    class MinMaxAvarageSumOfIntegers
    {
        //Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers do you want to calculate minimum, maximum, average, sum and product for ?");
            int lenghtOfArray = int.Parse(Console.ReadLine());
            int[] numArr = new int[lenghtOfArray];
            FillArray(numArr);
            Console.WriteLine("The minimum is: {0}", MinOfArray(numArr));
            Console.WriteLine("The maximum is: {0}", MaxOfArray(numArr));
            Console.WriteLine("The average is: {0}", AverageOfArray(numArr));
            Console.WriteLine("The sum is: {0}", SumOfArray(numArr));
            Console.WriteLine("The product is: {0}", ProductOfArray(numArr));
        }

        private static void FillArray(int[] numArr)
        {
            for (int i = 0; i < numArr.Length; i++)
            {
                numArr[i] = int.Parse(Console.ReadLine());
            }
        }

        private static int AverageOfArray(int[] array)
        {
            BigInteger result = SumOfArray(array);
            result = result / array.Length;
            return (int)result;
        }

        private static BigInteger SumOfArray(int[] array)
        {
            BigInteger result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }

        private static BigInteger ProductOfArray(int[] array)
        {
            BigInteger result = 1;
            for (int i = 0; i < array.Length; i++)
            {
                result *= array[i];
            }
            return result;
        }

        private static int MinOfArray(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i]; 
                }
            }
            return min;
        }

        private static int MaxOfArray(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}
