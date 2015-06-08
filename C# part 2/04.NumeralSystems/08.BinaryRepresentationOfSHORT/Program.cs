using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.BinaryRepresentationOfSHORT
{
    //Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter SHORT number: ");
            short number = short.Parse(Console.ReadLine());
            Console.WriteLine("The number is:");
            Console.WriteLine(GetBinary(number));
        }

        static string GetBinary(short number)
        {
            string result = String.Empty;
            for (int i = 0; i < 16; i++) 
            { 
                result = (number >> i & 1) + result; 
            }
            return result;
        }
    }
}
