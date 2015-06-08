using System;

namespace _01.DecimalToBinary
{
    //Write a program to convert decimal numbers to their binary representation.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to convert:");
            int numberToConvert = int.Parse(Console.ReadLine());
            Console.WriteLine(ConvertDecimalToBinary(numberToConvert));
        }

        public static string ConvertDecimalToBinary(int number)
        {
            string result = string.Empty;
            while (number != 0)
            {
                result = number % 2 + result;
                number /= 2;
            }
            return result;
        }
    }
}
