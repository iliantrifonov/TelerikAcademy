using System;
using System.Collections.Generic;

namespace _20.ExtractPalindromes
{
    //Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

    class Program
    {
        static void Main(string[] args)
        {
            string text = "abba ABBA zzss lamal exe assa ddda sadada";
            List<string> palindromes = GetPalindromes(text);
            foreach (var item in palindromes)
            {
                Console.WriteLine(item);
            }
        }

        private static List<string> GetPalindromes(string text)
        {
            string[] splitText = text.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);// we can add more here if necessary

            List<string> result = new List<string>();
            foreach (var item in splitText)
            {
                bool isPalindrome = true;
                for (int i = 0; i < item.Length / 2; i++)
                {
                    if (item[i] != item[item.Length - 1 - i])
                    {
                        isPalindrome = false;
                        break;
                    }
                }
                if (isPalindrome)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
