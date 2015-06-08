using System;

namespace _05.HexToBinary
{
    //Write a program to convert hexadecimal numbers to binary numbers (directly).

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hexadecimal representation of the number, and use capital letters: ");
            string hexadecimalNumber = Console.ReadLine();
            Console.WriteLine("The number is:");
            Console.WriteLine(ConvertHexToBinary(hexadecimalNumber));
        }

        private static string ConvertHexToBinary(string input)
        {
            int binary = 0;
            int count = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                switch (input[i])
                {
                    case 'A': 
                        binary = binary | (10 << 4 * count); 
                        break;
                    case 'B': 
                        binary = binary | (11 << 4 * count); 
                        break;
                    case 'C': 
                        binary = binary | (12 << 4 * count); 
                        break;
                    case 'D': 
                        binary = binary | (13 << 4 * count); 
                        break;
                    case 'E': 
                        binary = binary | (14 << 4 * count);
                        break;
                    case 'F': 
                        binary = binary | (15 << 4 * count); 
                        break;
                    default: 
                        binary = binary | ((input[i] - 48) << 4 * count);
                        break;
                }
                count++;
            }
            return Convert.ToString(binary, 2);
        }
    }
}
