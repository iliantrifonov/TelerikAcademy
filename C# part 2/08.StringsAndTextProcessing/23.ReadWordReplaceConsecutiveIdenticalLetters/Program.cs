using System;
using System.Text;

namespace _23.ReadWordReplaceConsecutiveIdenticalLetters
{
    //Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a non empty string: ");
            string word = Console.ReadLine();
            char letter = word[0];
            StringBuilder sb = new StringBuilder();
            sb.Append(letter);
            for (int i = 1; i < word.Length; i++)
            {
                if (letter != word[i])
                {
                    sb.Append(word[i]);
                }
                letter = word[i];
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
