using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DecodeAndDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int index = 0;
            for (int i = code.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(code[i]))
                {
                    sb.Append(code[i].ToString());
                }
                else
                {
                    index = i;
                    break;
                }
            }
            StringBuilder sb2 = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                sb2.Append(sb[i]);
            }
            int lenght = int.Parse(sb2.ToString());
            code = code.Remove(index + 1);
            code = Decode(code);
            string key = code.Substring(code.Length - lenght);
            code = code.Remove(code.Length - lenght);
            code = Encrypt(code, key);
            Console.WriteLine(code);
        }

        private static string Encode(string text)
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            char current = text[0];
            for (int i = 1; i < text.Length; i++)
            {
                if (current == text[i])
                {
                    count++;
                }
                else if (count == 2)
                {
                    sb.AppendFormat("{0}{0}", current);
                    count = 1;
                    current = text[i];
                }
                else 
                {
                    sb.AppendFormat("{0}{1}", count, current);
                    count = 1;
                    current = text[i];
                }
            }
            if (count == 2)
            {
                sb.AppendFormat("{0}{0}", current);
            }
            else
            {
                sb.AppendFormat("{0}{1}", count, current);
            }
            return sb.ToString();
        }

        public static string Decode(string text)
        {
            string a = "";
            int count = 0;
            StringBuilder sb = new StringBuilder();
            char current = char.MinValue;
            for (int i = 0; i < text.Length; i++)
            {
                current = text[i];
                if (char.IsDigit(current))
                {
                    a += current;
                }
                else if (a == "")
                {
                    sb.Append(current);
                }
                else 
                {
                    count = int.Parse(a);
                    a = "";
                    for (int j = 0; j < count; j++)
                    {
                        sb.Append(current);
                    }
                }
            }
            return sb.ToString();
        }

        private static string Encrypt(string text, string key)
        {
            int counter = 0;
            char[] textCharArr = text.ToCharArray();
            char[] keyCharArr = key.ToCharArray();
            StringBuilder sb = new StringBuilder();
            
            if (textCharArr.Length > keyCharArr.Length)
            {
                for (int i = 0; i < textCharArr.Length; i++)
                {
                    sb.Append((EncryptNum(textCharArr[i], keyCharArr[counter])).ToString());
                    counter++;
                    if (counter == keyCharArr.Length)
                    {
                        counter = 0;
                    }
                } 
            }
            else
            {
                while (counter < keyCharArr.Length)
                {
                    for (int i = 0; i < textCharArr.Length; i++)
                    {
                        textCharArr[i] = EncryptNum(textCharArr[i], keyCharArr[counter]);
                        counter++;
                        if (counter == keyCharArr.Length)
                        {
                            break;
                        }
                    }
                }
                for (int i = 0; i < textCharArr.Length; i++)
                {
                    sb.Append(textCharArr[i].ToString());
                }
            }
            
            return sb.ToString();
        }

        private static char EncryptNum(char character, char secondChar) 
        {
            int num;
            int secNum;
            if (char.IsDigit(character))
            {
                num = (int)character;
            }
            else
            {
                num = character - 'A';
            }
            if (char.IsDigit(secondChar))
            {
                secNum = (int)secondChar;
            }
            else
            {
                secNum = secondChar - 'A';
            }
            int resultNum = num ^ secNum;
            resultNum += 65;
            return (char)resultNum;
        }
    }
}
