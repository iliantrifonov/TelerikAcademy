using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.ReadStringPringLetterInEachStringAndTimesFound
{
    //Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found. 

    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int[] valuesOfEachLetter = new int['z' - 'a' + 1];
            foreach (char c in text.ToLower())
            {
                if ('a' <= c && c <= 'z') 
                { 
                    valuesOfEachLetter[c - 'a']++; 
                }
            }
            for (int i = 0; i < valuesOfEachLetter.Length; i++)
            {
                if (valuesOfEachLetter[i] != 0)
                {
                    Console.WriteLine("{0}: {1}", (char)(i + 'a'), valuesOfEachLetter[i]);
                }
            }
        }
    }
}
