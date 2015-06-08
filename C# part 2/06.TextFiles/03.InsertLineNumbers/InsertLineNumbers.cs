using System.IO;

namespace _03.InsertLineNumbers
{
    //Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

    class InsertLineNumbers
    {
        static void Main(string[] args)
        {
            StreamReader fileReader = new StreamReader(@"..\..\text.txt");
            StreamWriter fileWriter = new StreamWriter(@"..\..\textLines.txt");
            using (fileReader)
            {
                using (fileWriter)
                {
                    string line = fileReader.ReadLine();
                    int lineNumber = 1;
                    while (line != null)
                    {
                        fileWriter.WriteLine("{0} : {1}", lineNumber, line);
                        line = fileReader.ReadLine();
                        lineNumber++;
                    }
                }
            }
        }
    }
}
