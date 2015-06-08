﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ax2 + bx + c = 0");
            double a = 3;
            double b = 4;
            double c = -1;
            double d;
            d = (b * b) - (4 * a * c);
            if (d >= 0)
            {
                double x1;
                x1 = ((-b) + Math.Sqrt(d)) / (2 * a);
                double x2;
                x2 = ((-b) - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine(" x1 = {0:0.00} , x2 = {1:0.00}.", x1, x2);
            }
            else
            {
                Console.WriteLine("The equation has no real root");
            }
        }
    }
}
