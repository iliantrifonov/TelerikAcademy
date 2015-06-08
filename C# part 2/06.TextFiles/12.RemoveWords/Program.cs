using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace _12.RemoveWords
{
    //Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

    class Program
    {
        static void Main(string[] args)
        {
            string entryFile = "../../text.txt";
            string keyWords = "../../words.txt";
            string outputFile = "../../result.txt";
            try
            {
                RemoveWordsFromFile(entryFile, outputFile, GetKeyWords(keyWords));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<string> GetKeyWords(string filePath)
        {
            List<string> wordsList = new List<string>();
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                string line = fileReader.ReadLine();
                while (line != null)
                {
                    string[] wordsInLine = line.Split(' ');
                    for (int i = 0; i < wordsInLine.Length; i++)
                    {
                        if (wordsInLine[i] != string.Empty)
                        {
                            wordsList.Add(wordsInLine[i]);
                        }
                    }
                    line = fileReader.ReadLine();
                }
            }
            return wordsList;
        }

        private static void RemoveWordsFromFile(string inputFilePath, string outputFilePath, List<string> words)
        {
            using (StreamReader fileReader = new StreamReader(inputFilePath))
            {
                using (StreamWriter fileWriter = new StreamWriter(outputFilePath))
                {
                    string line = fileReader.ReadLine();
                    while (line != null)
                    {
                        foreach (string item in words)
                        {
                            string regexExpression = @"\b" + @item + @"\b";
                            line = Regex.Replace(line, @regexExpression, String.Empty);
                        }
                        fileWriter.WriteLine(line);
                        line = fileReader.ReadLine();
                    }
                }
            }
        }
    }
}
