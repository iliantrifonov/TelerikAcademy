using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _25.ParseHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (StreamReader reader = new StreamReader(@"..\..\text.html"))
            {
                string line = string.Empty;
                MatchCollection matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");
                while ((line = reader.ReadLine()) != null)
                {
                    matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");
                    foreach (var word in matchProtocolAndSiteName)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
