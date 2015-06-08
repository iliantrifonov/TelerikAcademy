using System;
using System.Text;

namespace _13.ReverseWordsInSentence
{
    //Write a program that reverses the words in given sentence.
	//Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

    class Program
    {
        static void Main(string[] args)
        {
            string text = "C# is not C++, not PHP and not Delphi!";
            char[] delimiters = { '.', '-', ',', ';', '?', '!', ' ' };
            StringBuilder result = new StringBuilder();
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] delimitersInSentence = text.Split(words, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);

            for (int i = 0; i < words.Length; i++)
            {
                result.Append(words[i]);
                result.Append(delimitersInSentence[i]);
            }
            Console.WriteLine(result);
        }
    }
}
