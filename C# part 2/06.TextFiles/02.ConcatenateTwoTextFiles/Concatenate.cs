using System.IO;

namespace _02.ConcatenateTwoTextFiles
{
    //Write a program that concatenates two text files into another text file.

    class Concatenate
    {
        static void Main(string[] args)
        {
            StreamReader firstReader = new StreamReader(@"..\..\text1.txt");
            StreamReader secondReader = new StreamReader(@"..\..\text2.txt");
            StreamWriter resultWriter = new StreamWriter(@"..\..\textResult.txt");
            string firstFile = string.Empty;
            string secondFile = string.Empty;
            using (firstReader)
            {
                firstFile = firstReader.ReadToEnd();
            }
            using (secondReader)
            {
                secondFile = secondReader.ReadToEnd();
            }
            using (resultWriter)
            {
                resultWriter.Write(firstFile);
                resultWriter.Write(secondFile);
            }
        }
    }
}
