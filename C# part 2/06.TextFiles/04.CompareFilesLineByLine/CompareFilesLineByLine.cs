using System.IO;
using System;

namespace _04.CompareFilesLineByLine
{
    //Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. Assume the files have equal number of lines.

    class CompareFilesLineByLine
    {
        static void Main(string[] args)
        {
            int equalLines = 0;
            int differentLines = 0;
            using (StreamReader firstReader = new StreamReader(@"..\..\text1.txt"))
            {
                using (StreamReader secondReader = new StreamReader(@"..\..\text2.txt"))
                {
                    string lineFileOne = firstReader.ReadLine();
                    string lineFileTwo = secondReader.ReadLine();
                    while (lineFileOne != null && lineFileTwo != null)
                    {
                        if (lineFileOne == lineFileTwo)
                        {
                            equalLines++;
                        }
                        else
                        {
                            differentLines++;
                        }
                        lineFileOne = firstReader.ReadLine();
                        lineFileTwo = secondReader.ReadLine();
                    }
                }
            }
            Console.WriteLine("There are {0} lines that are the same, and {1} lines that are different", equalLines, differentLines);
        }
    }
}
