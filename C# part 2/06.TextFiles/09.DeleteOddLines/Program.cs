using System.Collections.Generic;
using System.IO;

namespace _09.DeleteOddLines
{
    class Program
    {
        static void Main(string[] args)// IMPORTANT, every time you "test" this program it will rewrite the file !
        {
            List<string> evenLinesList = new List<string>();
            using (StreamReader fileReader = new StreamReader(@"..\..\text.txt"))
            {
                string line = fileReader.ReadLine();
                int lineCounter = 1;
                while (line != null)
                {
                    if (lineCounter % 2 == 0)
                    {
                        evenLinesList.Add(line);
                    }
                    lineCounter++;
                    line = fileReader.ReadLine();
                }
            }
            using (StreamWriter fileWriter = new StreamWriter(@"..\..\text.txt"))
            {
                for (int i = 0; i < evenLinesList.Count; i++)
                {
                    fileWriter.WriteLine(evenLinesList[i]);
                }
            }
        }
    }
}
