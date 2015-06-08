using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ExchangeValuesIfGreater
{
    class ExchangeValuesIfGreater
    {
        static void Main(string[] args)
        {
            int a = 7;
            int b = 6;
            if (a > b)
            {
                int c = a;
                a = b;
                b = c;
            }
            Console.WriteLine("a = {0} , b = {1}", a, b);
        }
    }
}
