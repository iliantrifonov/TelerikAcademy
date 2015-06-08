using System;
using System.Collections.Generic;

namespace _22.ReadTextExtractWords
{
    //Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.

    class Program
    {
        static void Main(string[] args)
        {
            string text = "word worz word word bla bla sss a";
            string[] allWords = text.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dictionary = new Dictionary<string,int>();
            foreach (var item in allWords)
	        {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item] += 1;
                }
                else
                {
                    dictionary.Add(item, 1);
                }
	        }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
    }
}
