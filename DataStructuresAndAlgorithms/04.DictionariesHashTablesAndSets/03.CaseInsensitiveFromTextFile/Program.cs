namespace _03.CaseInsensitiveFromTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that counts how many times each word from given text file words.txt appears in it. The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text. Example:
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var textInFile = File.ReadAllText("../../TextFiles/text.txt");
            var words = textInFile.Split(new[] { '.', ' ', ',', '!', '-', '_', '?', '?', '=' }, StringSplitOptions.RemoveEmptyEntries);

            var numberOccurences = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!numberOccurences.ContainsKey(word.ToLowerInvariant()))
                {
                    numberOccurences.Add(word.ToLowerInvariant(), 0);
                }

                numberOccurences[word.ToLowerInvariant()]++;
            }

            foreach (var occurencePair in numberOccurences)
            {
                Console.WriteLine("{0} -> {1}", occurencePair.Key, occurencePair.Value);
            }
        }
    }
}
