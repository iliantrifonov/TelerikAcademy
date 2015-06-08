using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Fibonacci100
{
    class Fibonacci100
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fibonacci :");
            int a = 0;
            int b = 1;
            Console.Write(a);
            Console.Write(", " + b);
            for (int i = 0; i < 98; i++)
            {
                int c;
                c = a + b;
                a = b;
                b = c;
                Console.Write(", " + c);
            }
        }
    }
}
