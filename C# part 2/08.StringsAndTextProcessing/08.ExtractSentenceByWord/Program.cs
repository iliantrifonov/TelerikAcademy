using System;
using System.Text.RegularExpressions;

namespace _08.ExtractSentenceByWord
{
    //Write a program that extracts from a given text all sentences containing given word.
    //    Example: The word is "in". The text is:
    //    The expected result is:
    //    Consider that the sentences are separated by "." and the words – by non-letter symbols.

    class Program
    {
        static void Main(string[] args)
        {
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            string word = "in";
            foreach (Match sentence in Regex.Matches(text, @"\s*([^\.]*\b" + word + @"\b.*?\.)"))
            {
                Console.WriteLine(sentence.Groups[1]);
            }
        }
    }
}
