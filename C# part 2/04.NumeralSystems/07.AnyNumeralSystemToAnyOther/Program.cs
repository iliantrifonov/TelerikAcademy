using System;
using System.Collections.Generic;

namespace _07.AnyNumeralSystemToAnyOther
{
    //Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

    class Program
    {
        static void Main()
        {
            Console.Write("Please enter a number: ");
            string number = (Console.ReadLine()).ToUpper();
            Console.Write("Please enter numeral system ( 2 to 16 ) to convert from: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Please enter numeral system ( 2 to 16 ) to convert to: ");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("The number is: ");
            ConvertFromDecimal(ConvertToDecimal(number, s), d);
        }

        static int ConvertToDecimal(string number, int baseFrom)
        {
            int decNum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] > '9')
                {
                    decNum += (number[i] - '7') * (int)Math.Pow(baseFrom, (number.Length - 1 - i));
                }
                else
                {
                    decNum += (number[i] - '0') * (int)Math.Pow(baseFrom, (number.Length - 1 - i));
                }
            }
            return decNum;
        }
        static void ConvertFromDecimal(int number, int baseTo)
        {
            List<int> result = new List<int>();
            if (baseTo > 10)
            {
                while (number > 0)
                {
                    result.Add(number % baseTo);
                    number = number / baseTo;
                }
                result.Reverse();
                foreach (var item in result)
                {
                    switch (item)
                    {
                        case 10: Console.Write("A");
                            break;
                        case 11: Console.Write("B");
                            break;
                        case 12: Console.Write("C");
                            break;
                        case 13: Console.Write("D");
                            break;
                        case 14: Console.Write("E");
                            break;
                        case 15: Console.Write("F");
                            break;
                        default: Console.Write(item);
                            break;
                    }
                }
                Console.WriteLine();
            }
            else
            {
                while (number > 0)
                {
                    result.Add(number % baseTo);
                    number = number / baseTo;
                }
                result.Reverse();
                foreach (var item in result)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }
    }
}
