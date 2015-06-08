
using System;

namespace _06.BinaryToHex
{
    //Write a program to convert binary numbers to hexadecimal numbers (directly).

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hexadecimal representation of the number, and use capital letters: ");
            string binaryNumber = Console.ReadLine();
            Console.WriteLine("The number is:");
            Console.WriteLine(ConvertBinatyToHex(binaryNumber));
        }

        static string ConvertBinatyToHex(string binary)
        {
            string hex = string.Empty;
            int remainder = binary.Length % 4;
            if (remainder != 0)
            {
                binary = binary.PadLeft(((binary.Length / 4) + 1) * 4, '0');
            }
            for (int i = 0; i < binary.Length; i += 4) // each 4 digits in binary equal a single letter
            {
                string digit = binary.Substring(i, 4);
                hex += string.Format("{0:X}", Convert.ToByte(digit, 2));
            }
            return hex.ToString();
        }
    }
}
