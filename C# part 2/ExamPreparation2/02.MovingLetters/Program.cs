using System;
using System.Text;
using System.Collections.Generic;

namespace MovingLetters
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = GenerateLetterSequenceFromWords(Console.ReadLine());
            string a = MovingLetters(sb);
            Console.WriteLine(a);
        }

        private static string MovingLetters(StringBuilder sb)
        {
            for (int pos = 0; pos < sb.Length; pos++)
            {
                char letter = sb[pos];
                int positions = char.ToLower(letter) - 'a' + 1;
                int newPos = (pos + positions) % sb.Length;
                sb.Remove(pos, 1);

                sb.Insert(newPos, letter);
            }
            return sb.ToString();
        }

        private static StringBuilder GenerateLetterSequenceFromWords(string a)
        {
            string[] words = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder(300);
            int maxSize = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > maxSize)
                {
                    maxSize = words[i].Length;
                }
            }
            for (int k = 0; k < maxSize; k++)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > k)
                    {
                        sb.Append(words[i][words[i].Length - 1 - k]);
                    }
                }
            }
            return sb;
        }
    }
}