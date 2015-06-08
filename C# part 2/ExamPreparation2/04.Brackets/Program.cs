using System.Text;
using System;

namespace Brackets
{
    class MainClass
    {

        public static StringBuilder indentation = new StringBuilder();
        public static int rows;
        public static string dentSymbols;
        public static void Main(string[] args)
        {
            //			string a = @"word word
            //
            //enter word
            //enter";
            //			char[] b = a.ToCharArray();
            //			Console.WriteLine ();
            rows = int.Parse(Console.ReadLine());
            dentSymbols = Console.ReadLine();
            //			int lenghtOfIndentation = dentSymbols.Length;
            for (int i = 0; i < rows; i++)
            {
                string text = Console.ReadLine().Trim();
                if (text.Length < 1)
                {
                    continue;
                }
                Console.WriteLine(FixBrackets(text));
            }
        }

        public static string FixBrackets(string text)
        {
            StringBuilder sb = new StringBuilder();
            if (text[0] == '}' && indentation.Length != 0)
            {
                indentation.Remove(indentation.Length - dentSymbols.Length, dentSymbols.Length);
            }
            sb.Append(indentation);
            char lastNonSpace = '{';
            //indentation.Remove(indentation.Length - dentSymbols.Length,dentSymbols.Length);
            //indentation.Append(dentSymbols);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '{')
                {
                    if (i != 0)
                    {
                        if (lastNonSpace != '}' && lastNonSpace != '{')
                        {
                            sb.Append('\n');
                        }
                        sb.Append(indentation);
                    }
                    sb.Append(text[i]);
                    if (i != text.Length - 1)
                    {
                        sb.Append('\n');
                    }
                    indentation.Append(dentSymbols);
                }
                else if (text[i] == '}')
                {

                    if (i != 0 && lastNonSpace != '{' && lastNonSpace != '}')
                    {
                        sb.Append('\n');
                    }
                    if (i != 0)
                    {
                        indentation.Remove(indentation.Length - dentSymbols.Length, dentSymbols.Length);
                        sb.Append(indentation);
                    }
                    sb.Append(text[i]);
                    if (i != text.Length - 1)
                    {
                        sb.Append('\n');
                    }
                }
                else if (text[i] == ' ')
                {

                }
                else
                {
                    if (i != 0 && text[i - 1] == ' ' && lastNonSpace != '{' && lastNonSpace != '}')
                    {
                        sb.Append(' ');
                    }
                    if (sb.Length != 0 && sb[sb.Length - 1] == '\n')
                    {
                        sb.Append(indentation);
                    }
                    sb.Append(text[i]);
                }
                if (text[i] != ' ')
                {
                    lastNonSpace = text[i];
                }
            }
            return sb.ToString();
        }
    }
}
