using System;
using System.Collections.Generic;
using System.IO;

namespace _06.SortListOfStringsInFile
{
    //Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:

    class Program
    {
        static void Main(string[] args) // We assume there is a single string per line
        {
            using (StreamReader fileReader = new StreamReader(@"..\..\stringList.txt"))
            {
                using (StreamWriter fileWriter = new StreamWriter(@"..\..\sortedStringList.txt"))
                {

                    List<string> stringsInFile = new List<string>();
                    string line = fileReader.ReadLine();
                    while (line != null)
                    {
                        stringsInFile.Add(line);
                        line = fileReader.ReadLine();
                    }
                    string[] arrayOfStrings = new string[stringsInFile.Count];
                    for (int i = 0; i < arrayOfStrings.Length; i++)
                    {
                        arrayOfStrings[i] = stringsInFile[i];
                    }
                    Array.Sort(arrayOfStrings);
                    for (int i = 0; i < arrayOfStrings.Length; i++)
                    {
                        fileWriter.WriteLine(arrayOfStrings[i]);
                    }
                }
            }

        }
    }
}
