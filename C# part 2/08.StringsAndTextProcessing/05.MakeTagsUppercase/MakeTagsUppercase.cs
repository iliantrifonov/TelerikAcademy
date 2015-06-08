using System;
using System.Text;

namespace _05.MakeTagsUppercase
{
    //You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
    //The expected result:

    class MakeTagsUppercase
    {
        static void Main(string[] args)
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            string tag = "upcase";
            Console.WriteLine(MakeUpperCaseFromTag(text,tag));
        }

        private static string MakeUpperCaseFromTag(string text, string tag)
        {
            string[] arrayOfText = text.Split('<', '>');
            bool foundTagUpper = false;
            for (int i = 0; i < arrayOfText.Length; i++)
            {
                if (arrayOfText[i] == tag)
                {
                    foundTagUpper = true;
                    arrayOfText[i] = null;
                }
                else if (arrayOfText[i] == @"/" + tag)
                {
                    foundTagUpper = false;
                    arrayOfText[i] = null;
                }
                else if (foundTagUpper)
                {
                    arrayOfText[i] = arrayOfText[i].ToUpper();
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrayOfText.Length; i++)
            {
                sb.Append(arrayOfText[i]);
            }
            return sb.ToString();
        }
    }
}
