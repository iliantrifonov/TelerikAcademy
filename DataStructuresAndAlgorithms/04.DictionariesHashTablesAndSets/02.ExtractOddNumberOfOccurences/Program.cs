namespace _02.ExtractOddNumberOfOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:
    /// {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var languages = new string[] { "C#", 
                                         "SQL", 
                                         "PHP", 
                                         "PHP", 
                                         "SQL", 
                                         "SQL" };

            var numberOccurences = new Dictionary<string, int>();

            foreach (var language in languages)
            {
                if (!numberOccurences.ContainsKey(language))
                {
                    numberOccurences.Add(language, 0);
                }

                numberOccurences[language]++;
            }

            var oddNumberOfOccurences = new HashSet<string>();
            foreach (var occurencePairs in numberOccurences)
            {
                if (occurencePairs.Value % 2 != 0)
                {
                    oddNumberOfOccurences.Add(occurencePairs.Key);
                }
            }

            foreach (var language in oddNumberOfOccurences)
            {
                Console.WriteLine(language);
            }
        }
    }
}
