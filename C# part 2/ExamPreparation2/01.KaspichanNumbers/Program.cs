using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.KaspichanNumbers
{
    class Program
    {
        static string[] numeralSystem;

        static void Main(string[] args)
        {
            numeralSystem = new string[256];
            for (int i = 0; i < numeralSystem.Length; i++)
            {
                if (i >= 0 && i <= 25)
                {
                    numeralSystem[i] = ((char)('A' + i)).ToString();
                }
                else
                {
                    for (int k = 0; k < 26; k++)
                    {
                        for (int b = 0; b < 26; b++)
                        {
                            numeralSystem[i] = ((char)('a' + k)).ToString() + ((char)('A' + b)).ToString();
                            i++;
                            if (i >= numeralSystem.Length)
                            {
                                break;
                            }
                        }
                        if (i >= numeralSystem.Length)
                        {
                            break;
                        }
                    }
                    if (i >= numeralSystem.Length)
                    {
                        break;
                    }
                }
            }

            string number = Console.ReadLine();

            int baseFrom = 10;
            int baseTo = 256;
            ConvertFromDecimal(ConvertToDecimal(number, baseFrom), baseTo);
        }

        static BigInteger ConvertToDecimal(string number, int baseFrom)
        {
            BigInteger decNum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] > '9')
                {
                    decNum += (number[i] - '7') * (BigInteger)Math.Pow(baseFrom, (number.Length - 1 - i));
                }
                else
                {
                    decNum += (number[i] - '0') * (BigInteger)Math.Pow(baseFrom, (number.Length - 1 - i));
                }
            }
            return decNum;
        }
        static void ConvertFromDecimal(BigInteger number, int baseTo)
        {
            List<int> result = new List<int>();
            if (baseTo > 10)
            {
                if (number == 0)
                {
                    result.Add(0);
                }
                while (number > 0)
                {
                    result.Add((int)(number % baseTo));
                    number = number / baseTo;
                }
                result.Reverse();

                for (int i = 0; i < result.Count; i++)
                {
                    Console.Write(numeralSystem[result[i]]);
                }
                Console.WriteLine();
            }
            else
            {
                if (number == 0)
                {
                    Console.WriteLine("0");
                    return;
                }
                while (number > 0)
                {
                    result.Add((int)(number % baseTo));
                    number = number / (long)baseTo;
                }
                result.Reverse();
                foreach (var item in result)
                {
                    Console.Write(item);
                }
            }
        }
    }
}
