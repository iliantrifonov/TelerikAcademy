using System;
using System.IO;

namespace _01.WriteOddLines
{
    //Write a program that reads a text file and prints on the console its odd lines.

    class WriteOddLines
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\text.txt");
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
