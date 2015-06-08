using System;

namespace _15.ModifyToWorkAsGeneric
{
    //* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).

    class Generic
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers do you want to calculate minimum, maximum, average, sum and product for ?");
            int lenghtOfArray = int.Parse(Console.ReadLine());
            float[] numArr = new float[lenghtOfArray];
            FillArray(numArr);
            Console.WriteLine("The minimum is: {0}", MinOfArray(numArr));
            Console.WriteLine("The maximum is: {0}", MaxOfArray(numArr));
            Console.WriteLine("The average is: {0}", AverageOfArray(numArr));
            Console.WriteLine("The sum is: {0}", SumOfArray(numArr));
            Console.WriteLine("The product is: {0}", ProductOfArray(numArr));
        }

        private static void FillArray<T>(T[] numArr)
        {
            for (int i = 0; i < numArr.Length; i++)
            {
                numArr[i] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));// like int.parse for all types
            }
        }

        private static T AverageOfArray<T>(T[] array)
        {
            dynamic result = SumOfArray(array);
            result = result / array.Length;
            return result;
        }

        private static T SumOfArray<T>(T[] array)
        {
            dynamic result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }

        private static T ProductOfArray<T>(T[] array)
        {
            dynamic result = 1;
            for (int i = 0; i < array.Length; i++)
            {
                result *= array[i];
            }
            return result;
        }

        private static T MinOfArray<T>(T[] array) where T : System.IComparable<T>
        {
            T min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min.CompareTo(array[i]) > 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        private static T MaxOfArray<T>(T[] array) where T : System.IComparable<T>
        {
            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max.CompareTo(array[i]) < 0)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}
