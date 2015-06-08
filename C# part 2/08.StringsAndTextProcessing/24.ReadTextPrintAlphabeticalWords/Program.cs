using System;

namespace _24.ReadTextPrintAlphabeticalWords
{
    //Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words separated by a single space: ");
            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            foreach (var item in words)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
