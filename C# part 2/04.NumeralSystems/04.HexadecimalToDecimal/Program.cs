using System;

namespace _04.HexadecimalToDecimal
{
    //Write a program to convert hexadecimal numbers to their decimal representation.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hexadecimal representation of the number, and use capital letters: ");
            string hexadecimalNumber = Console.ReadLine();
            Console.WriteLine("The number is:");
            Console.WriteLine(ConvertToHexadecimal(hexadecimalNumber));
        }

        public static int ConvertToHexadecimal(string binaryNumber, int baseOfConversion = 16)
        {
            int result = 0;
            int startBase = 1;
            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                result += GetNumber(binaryNumber[i]) * startBase;
                startBase *= baseOfConversion;
            }
            return result;
        }

        static int GetNumber(char digit)
        {
            if (digit >= 'A')
            {
                return digit - 'A' + 10;
            }
            else
            {
                return digit - '0';
            }
        }
    }
}
