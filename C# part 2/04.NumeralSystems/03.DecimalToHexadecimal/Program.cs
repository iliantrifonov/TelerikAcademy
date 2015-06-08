using System;
using System.Text;

namespace _03.DecimalToHexadecimal
{
    //Write a program to convert decimal numbers to their hexadecimal representation.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to convert:");
            int numberToConvert = int.Parse(Console.ReadLine());
            Console.WriteLine(ConvertDecToHex(numberToConvert));
        }

        private static string ConvertDecToHex(int numberToConvert)
        {
            StringBuilder hexNum = new StringBuilder();
            while (numberToConvert > 0)
            {
                switch (numberToConvert % 16)
                {
                    case 10:
                        hexNum.Append('A');
                        break;
                    case 11:
                        hexNum.Append('B');
                        break;
                    case 12:
                        hexNum.Append('C');
                        break;
                    case 13:
                        hexNum.Append('D');
                        break;
                    case 14:
                        hexNum.Append('E');
                        break;
                    case 15:
                        hexNum.Append('F');
                        break;
                    default:
                        hexNum.Append(numberToConvert % 16);
                        break;
                }
                numberToConvert = numberToConvert / 16;
            }
            StringBuilder result = new StringBuilder();
            for (int i = hexNum.Length - 1; i >= 0; i--)
            {
                result.Append(hexNum[i]);
            }
            return result.ToString();
        }


    }
}
