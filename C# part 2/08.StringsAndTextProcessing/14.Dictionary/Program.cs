using System;
using System.Collections.Generic;

namespace _14.Dictionary
{
    //A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary. Sample dictionary:

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Search for a word: ");
            string word = Console.ReadLine();
            Console.WriteLine("{0} - {1}", word, GetDescription(word));
        }

        private static string GetDescription(string word)
        {
            word = word.Trim();
            var dictionary = new Dictionary<string, string>();
            dictionary.Add(".NET", "platform for applications from Microsoft");
            dictionary.Add("CLR", "managed execution environment for .NET");
            dictionary.Add("namespace", "hierarchical organization of classes");

            foreach (var entry in dictionary)
            {
                if (entry.Key.ToLowerInvariant() == word.ToLowerInvariant()) // this will only do COMPLETE matches, we can use regex for others if necessary
                {
                    return entry.Value;
                }
            }

            return "not found";
        }
    }
}
