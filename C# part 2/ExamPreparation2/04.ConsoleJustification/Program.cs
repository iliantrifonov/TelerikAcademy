using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsoleJustification
{
    class Program
    {
        private static int index = 0;
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int sizeOfLines = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                sb.Append(Console.ReadLine() + " ");
            }
            string text = sb.ToString();

            string[] arrOfWords = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (index < arrOfWords.Length)
            {
                List<string> lineResult = GetJustified(arrOfWords, sizeOfLines);
                sb = new StringBuilder();
                for (int i = 0; i < lineResult.Count; i++)
                {
                    sb.Append(lineResult[i]);
                }
                Console.WriteLine(sb.ToString());
            }

        }

        private static List<string> GetJustified(string[] arr, int widthOfLines)
        {
            List<string> listOfWords = new List<string>(widthOfLines);
            int currentWidth = 0;
            int currentLenghtOfWords = 0;
            int countHowManyWords = 0;
            while (currentWidth <= widthOfLines)
            {
                currentLenghtOfWords += arr[index].Length + 1;
                listOfWords.Add(arr[index]);
                listOfWords.Add(" ");
                countHowManyWords++;
                if (index + 1 > arr.Length - 1)
                {
                    index++;
                    break;
                }
                currentWidth = currentLenghtOfWords + arr[index + 1].Length;
                index++;
            }
            listOfWords.RemoveAt(listOfWords.Count - 1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listOfWords.Count; i++)
            {
                sb.Append(listOfWords[i]);
            }
            if (countHowManyWords == 1)
            {
                
            }
            else if (sb.Length < widthOfLines)
            {
                AddSpaces(ref listOfWords, widthOfLines);
            }
            return listOfWords;
        }

        private static void AddSpaces(ref List<string> wordsOnLine, int widthOfLines)
        {
            int i = 0;
            int currentWidth = 0;
            while (currentWidth < widthOfLines)
            {
                if (wordsOnLine[i] == " ")
                {
                    wordsOnLine.Insert(i, " ");
                    while (wordsOnLine[i] == " ")
                    {
                        i++;
                    }
                    currentWidth = 0;
                    for (int z = 0; z < wordsOnLine.Count; z++)
                    {
                        currentWidth += wordsOnLine[z].Length;
                    }
                }
                else
                {
                    i++;
                }
                if (i >= wordsOnLine.Count)
                {
                    i = 0;
                }
            }
        }
    }
}
