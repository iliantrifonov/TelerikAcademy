using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01._9GagNumbers
{
    class Program
    {
        public static string[] numeralSystem;
        static void Main(string[] args)
        {
            CreateNumericalSystem();
            string number = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            List<string> numberParts = new List<string>();

            for (int i = 0; i < number.Length; i++)
            {
                sb.Append(number[i]);
                if (sb.Length > 1)
                {
                    if (ArrayContains(sb.ToString(), numeralSystem))
                    {
                        numberParts.Add(sb.ToString());
                        sb.Clear();
                    }
                }
            }
            

            int baseFrom = 9;
            int baseTo = 10;
            ConvertFromDecimal(ConvertToDecimal(numberParts, baseFrom), baseTo);
        }

        private static bool AreLenghtsEqual(string number, List<string> list)
        {
            int lenght = 0;
            for (int i = 0; i < list.Count; i++)
            {
                lenght += list[i].Length;
            }
            if (lenght == number.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string ReverseString(string p)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < p.Length; i++)
            {
                sb.Append(p[p.Length - 1 - i]);
            }
            return sb.ToString();
        }

        private static bool ArrayContains(string key, string[] numeralSys)
        {
            for (int i = 0; i < numeralSys.Length; i++)
            {
                if (key == numeralSys[i])
                {
                    return true;
                }  
            }
            return false;
        }

        private static int GetIndex(string digit)
        {
            for (int i = 0; i < numeralSystem.Length; i++)
            {
                if (digit == numeralSystem[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private static void CreateNumericalSystem()
        {
            numeralSystem = new string[] { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        }

        static BigInteger ConvertToDecimal(List<string> number, int baseFrom)
        {
            BigInteger decNum = 0;
            for (int i = 0; i < number.Count; i++)
            {
                decNum += GetIndex(number[i]) * Pow(baseFrom, (number.Count - 1 - i));
            }
            return decNum;
        }

        private static BigInteger Pow(int number, int power)
        {
            BigInteger result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
            }
            return result;
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
