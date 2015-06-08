namespace RefactorVariableUsageAndBestNaming
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            double[] arr = { 3.2, 1, 21, 22.3 };
            PrintArrayStatistics(arr);
        }

        public static void PrintArrayStatistics(double[] array)
        {
            PrintMax(array);
            PrintMin(array);
            PrintAverage(array);
        }

        public static void PrintMax(double[] array)
        {
            Console.WriteLine(GetMax(array));
        }

        public static void PrintMin(double[] array)
        {
            Console.WriteLine(GetMin(array));
        }

        public static void PrintAverage(double[] array)
        {
            Console.WriteLine(GetAvarage(array));
        }

        public static double GetMax(double[] array)
        {
            double max = double.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public static double GetMin(double[] array)
        {
            double min = double.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public static double GetAvarage(double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            double avarage = sum / array.Length;
            return avarage;
        }
    }
}