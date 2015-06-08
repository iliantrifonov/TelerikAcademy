using System;
using System.Collections.Generic;
using System.IO;

namespace _13.CountWordOccurences
{
    //Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.

    class Program
    {
        static void Main(string[] args)
        {
            string entryFilePath = "../../text.txt";
            string filePathWords = "../../words.txt";
            string resultFilePath = "../../result.txt";
            try
            {
                List<string> words = GetKeyWords(filePathWords);
                int[] counterForEachWord = new int[words.Count];
                CountKeyWords(entryFilePath, words, counterForEachWord);
                string[] arrayWords = words.ToArray();
                Array.Sort(counterForEachWord, arrayWords);
                using (StreamWriter fileWriter = new StreamWriter(resultFilePath))
                {
                    for (int i = arrayWords.Length - 1; i >= 0; i--)
                    {
                        fileWriter.WriteLine("{0}: {1}", arrayWords[i], counterForEachWord[i]);
                    }
                }
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

        /// <summary>
        /// Fills int[] counterForEachWord with the amounts of times each word is met. words.Count = counterForEachWord.Lenght  !!!
        /// </summary>
        /// <param name="entryFilePath"></param>
        /// <param name="words"></param>
        /// <param name="counterForEachWord"></param>
        private static void CountKeyWords(string entryFilePath, List<string> words, int[] counterForEachWord)
        {
            using (StreamReader fileReader = new StreamReader(entryFilePath))
            {
                string line = fileReader.ReadLine();
                while (line != null)
                {
                    string[] wordsInLine = line.Split(' ');
                    for (int indexKeyWords = 0; indexKeyWords < words.Count; indexKeyWords++)
                    {
                        for (int indexWordsInTextFile = 0; indexWordsInTextFile < wordsInLine.Length; indexWordsInTextFile++)
                        {
                            if (words[indexKeyWords] == wordsInLine[indexWordsInTextFile])
                            {
                                counterForEachWord[indexKeyWords]++;
                            }
                        }
                    }
                    line = fileReader.ReadLine();
                }
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
    }
}
