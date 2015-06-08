using System;
using System.Collections.Generic;
using System.Text;

namespace MagicWords
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] wordsArr = new string[n];
            for (int i = 0; i < wordsArr.Length; i++)
            {
                wordsArr[i] = Console.ReadLine();
            }
            List<string> a = MoveWords(wordsArr);
            Console.WriteLine(PrintList(a));
        }

        private static string PrintList(List<string> words)
        {
            int maxLenght = 0;
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length > maxLenght)
                {
                    maxLenght = words[i].Length;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < maxLenght; i++)
            {
                for (int z = 0; z < words.Count; z++)
                {
                    if (words[z].Length - 1 < i)
                    {
                        continue;
                    }
                    sb.Append(words[z][i]);
                }
            }
            return sb.ToString();
        }

        private static List<string> MoveWords(string[] wordsArr)
        {

            List<string> wordsList = new List<string>();
            for (int i = 0; i < wordsArr.Length; i++)
            {
                wordsList.Add(wordsArr[i]);
            }
            for (int i = 0; i < wordsList.Count; i++)
            {
                string word = wordsList[i];
                int position = word.Length % (wordsList.Count + 1);
                wordsList.Insert(position, word);
                if (position <= i)
                {
                    wordsList.RemoveAt(i + 1);
                }
                else
                {
                    wordsList.RemoveAt(i);
                }
            }
            return wordsList;
        }
    }
}