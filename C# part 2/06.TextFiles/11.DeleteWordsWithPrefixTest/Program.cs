using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _11.DeleteWordsWithPrefixTest
{
    //Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileReader = new StreamReader(@"..\..\text.txt"))
            {
                using (StreamWriter fileWriter = new StreamWriter(@"..\..\result.txt"))
                {
                    string line = fileReader.ReadLine();
                    while (line != null)
                    {
                        line = Regex.Replace(line, @"\btest\w*\b", String.Empty);
                        fileWriter.WriteLine(line);
                        line = fileReader.ReadLine();
                    }
                }
            }
        }
    }
}
