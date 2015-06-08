using System.IO;

namespace _07.ReplaceStartWithFinish
{
    //Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with files (e.g. 100 MB).

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
                        fileWriter.WriteLine(line.Replace("start", "finish"));
                    }
                }
            }
        }
    }
}
