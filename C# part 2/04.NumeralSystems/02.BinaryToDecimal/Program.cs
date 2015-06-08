using System;

namespace _02.BinaryToDecimal
{
    //Write a program to convert binary numbers to their decimal representation.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter binary representation of the number: ");
            string binaryNumber = Console.ReadLine();
            Console.WriteLine("The number is:");
            Console.WriteLine(ConvertToDecimal(binaryNumber));
        }

        public static int ConvertToDecimal(string binaryNumber, int baseOfConversion = 2)
        {
            int result = 0;
            int startBase = 1;
            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                result += (binaryNumber[i] - '0') * startBase;
                startBase *= baseOfConversion;
            }
            return result;
        }
    }
}
