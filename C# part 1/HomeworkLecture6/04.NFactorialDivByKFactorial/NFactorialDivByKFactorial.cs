﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.NFactorialDivByKFactorial
{
    class NFactorialDivByKFactorial
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N > K > 1");
            Console.WriteLine("Please enter N:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter K:");
            int k = int.Parse(Console.ReadLine());
            int result = 1;
            for (int i = k + 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);
        }
    }
}
