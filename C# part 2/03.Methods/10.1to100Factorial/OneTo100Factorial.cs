using System;
using System.Collections.Generic;

namespace _10._1to100Factorial
{
    //Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

    class OneTo100Factorial
    {
        static void Main(string[] args)
        {
            List<int> factorial = new List<int>();
            factorial.Add(1);
            for (int i = 1; i < 100; i++)
            {
                CalcFactorial(factorial, i);
                PrintList(factorial);
            }
        }

        private static void CalcFactorial(List<int> factorial, int n)
        {
            List<int> factCopy = new List<int>();
            for (int i = 0; i < factorial.Count; i++)
            {
                factCopy.Add(factorial[i]);
            }
            for (int i = factCopy.Count - 1; i >= 0; i--)
            {
                int result = 0;
                int carryTens = 0;
                int carryHundreds = 0;
                result = factCopy[i] * n;
                factorial[i] = result % 10;

                if (result > 99)
                {
                    carryHundreds = result / 100;
                    carryTens = (result / 10) % 10;
                }
                else if (result > 9)
                {
                    carryTens = result / 10;
                }

                if (carryTens > 0)
                {
                    if (factorial.Count < i + 2)
                    {
                        factorial.Add(carryTens);
                    }
                    else
                    {
                        factorial[i + 1] += carryTens;
                        if (factorial[i + 1] > 9)
                        {
                            factorial[i + 1] %= 10;
                            carryHundreds++;
                        }

                    }
                }
                if (carryHundreds > 0)
                {
                    if (factorial.Count < i + 3)
                    {
                        factorial.Add(carryHundreds);
                    }
                    else
                    {
                        factorial[i + 2] += carryHundreds;
                    }
                }
            }
        }

        private static void PrintList(List<int> listOfNumbers)
        {
            for (int i = listOfNumbers.Count - 1; i >= 0; i--)
            {
                Console.Write(listOfNumbers[i]);
            }
            Console.WriteLine();
        }
    }
    
}
