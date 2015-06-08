
using System;
using System.IO;

namespace _10.ExtractTextFromHTML
{
    //Write a program that extracts from given XML file all the text without the tags. Example:

    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileReader = new StreamReader(@"..\..\html.html"))
            {
                for (int character; (character = fileReader.Read()) != -1; ) // Read char by char
                {
                    if (character == '>')
                    {
                        string text = String.Empty;

                        while ((character = fileReader.Read()) != -1 && character != '<') 
                        { 
                            text += (char)character; 
                        }

                        if (!String.IsNullOrWhiteSpace(text)) 
                        { 
                            Console.WriteLine(text.Trim()); 
                        }
                    }
                }
            }
        }
    }
}
