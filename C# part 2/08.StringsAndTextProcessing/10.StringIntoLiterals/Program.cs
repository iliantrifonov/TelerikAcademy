using System;

namespace _10.StringIntoLiterals
{
    //Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hi!";
            foreach (char item in text)
            {
                Console.Write("\\u{0:X4}", (int)item);
            }
            Console.WriteLine();
        }
    }
}
