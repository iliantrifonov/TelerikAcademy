﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.Zerg
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
                if (sb.Length == 4)
                {
                    numberParts.Add(sb.ToString());
                    sb.Clear();
                }
            }

            int baseFrom = 15;
            int baseTo = 10;
            ConvertFromDecimal(ConvertToDecimal(numberParts, baseFrom), baseTo);
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
            numeralSystem = new string[] { "Rawr" , "Rrrr" , "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz" , "Bauu", "Djav" , "Myau", "Gruh"};
        }

        static BigInteger ConvertToDecimal(List<string> number, int baseFrom)
        {
            BigInteger decNum = 0;
            for (int i = 0; i < number.Count; i++)
            {
                decNum += GetIndex(number[i]) * (BigInteger)Math.Pow(baseFrom, (number.Count - 1 - i));
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