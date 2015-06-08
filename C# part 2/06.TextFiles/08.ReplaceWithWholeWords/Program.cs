using System.Text.RegularExpressions;
using System.IO;

namespace _08.ReplaceWithWholeWords
{
    //Modify the solution of the previous problem to replace only whole words (not substrings).

    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileReader = new StreamReader(@"..\..\text.txt"))
            {
                using (StreamWriter fileWriter = new StreamWriter(@"..\..\result.txt"))
                {
                    for (string line = fileReader.ReadLine(); line != null; line = fileReader.ReadLine())
                    {
                        fileWriter.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
                    }
                }
            }
        }
    }
}
