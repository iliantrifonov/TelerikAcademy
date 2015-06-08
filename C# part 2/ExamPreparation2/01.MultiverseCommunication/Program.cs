using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MultiverseCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            string[] keyArray = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
            StringBuilder numberReady = new StringBuilder();
            for (int i = 0; i < number.Length; i++)
            {
                StringBuilder numberIn13 = new StringBuilder();
                numberIn13.Append(number[i].ToString());
                i++;
                numberIn13.Append(number[i].ToString());
                i++;
                numberIn13.Append(number[i].ToString());
                string numAsNumbersIn13 = string.Empty;
                string partOfNum13 = numberIn13.ToString();
                for (long k = 0; k < keyArray.Length; k++)
                {
                    if (partOfNum13 == keyArray[k])
                    {
                        if (k > 9)
                        {
                            if (k == 10)
                            {
                                numAsNumbersIn13 = "A";
                            }
                            else if (k == 11)
                            {
                                numAsNumbersIn13 = "B";
                            }
                            else if (k == 12)
                            {
                                numAsNumbersIn13 = "C";
                            }
                        }
                        else
                        {
                            numAsNumbersIn13 = k.ToString();
                        }
                        numberReady.Append(numAsNumbersIn13);
                        break;
                    }
                }
            }

            int baseFrom = 13;
            int baseTo = 10;
            ConvertFromDecimal(ConvertToDecimal(numberReady.ToString(), baseFrom), baseTo);
        }

        static long ConvertToDecimal(string number, int baseFrom)
        {
            long decNum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] > '9')
                {
                    decNum += (number[i] - '7') * (long)Math.Pow(baseFrom, (number.Length - 1 - i));
                }
                else
                {
                    decNum += (number[i] - '0') * (long)Math.Pow(baseFrom, (number.Length - 1 - i));
                }
            }
            return decNum;
        }
        static void ConvertFromDecimal(long number, int baseTo)
        {
            List<long> result = new List<long>();
            if (baseTo > 10)
            {
                if (number == 0)
                {
                    result.Add(0);
                }
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
            }
        }
    }
}
