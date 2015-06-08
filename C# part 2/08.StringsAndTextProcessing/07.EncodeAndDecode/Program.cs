using System;
using System.Text;

namespace _07.EncodeAndDecode
{
    //Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to encode: ");
            string text = Console.ReadLine();
            Console.WriteLine("Enter key:");
            string key = Console.ReadLine();
            Console.WriteLine("The encripted text is: ");
            text = EncodeDecode(text, key);
            Console.WriteLine(text);

            Console.WriteLine("The original text is: ");
            Console.WriteLine(EncodeDecode(text, key));

        }

        private static string EncodeDecode(string text, string key)
        {
            int keyCharCounter = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append((char)(text[i] ^ key[keyCharCounter]));
                keyCharCounter++;
                if (keyCharCounter == key.Length)
                {
                    keyCharCounter = 0;
                }
            }
            return sb.ToString();
        }
    }
}
