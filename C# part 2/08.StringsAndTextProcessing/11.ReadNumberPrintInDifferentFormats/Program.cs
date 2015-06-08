using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ReadNumberPrintInDifferentFormats
{
    //Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. Format the output aligned right in 15 symbols.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Decimal : \r\n{0, 15:D}", number);
            Console.WriteLine("Hexadecimal : \r\n{0, 15:X}", number);
            Console.WriteLine("Percentage : \r\n{0, 15:C}", number);
            Console.WriteLine("Scientific : \r\n{0, 15:E}", number);
        }
    }
}
