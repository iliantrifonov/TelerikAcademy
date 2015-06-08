using System;

namespace _06.ReadMax20Chars
{
    //Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string with a maximum of 20 characters:");
            string text = Console.ReadLine();
            if (text.Length > 20)
            {
                Console.WriteLine("Invalid input, the string is too large");
            }
            else
            {
                Console.WriteLine(text.PadRight(20,'*'));
            }
        }
    }
}
