
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.A_nacci
{
    class Anacci
    {
        static void Main(string[] args)
        {
            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine(firstChar);
            int first = firstChar - 'A' + 1;
            int second = secondChar - 'A' + 1;
            for (int i = 2; i <= rows; i++)
            {
                int third = first + second;
                if (third > 26)
                {
                    third %= 26;
                }
                first = second;
                second = third;
                Console.Write(alphabet[first]);
                for (int i2 = 2; i2 < i; i2++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(alphabet[second]);
                third = first + second;
                if (third > 26)
                {
                    third %= 26;
                }
                first = second;
                second = third;
            }
        }
    }
}
