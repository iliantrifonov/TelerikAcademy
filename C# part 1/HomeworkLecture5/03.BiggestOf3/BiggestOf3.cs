using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BiggestOf3
{
    class BiggestOf3
    {
        static void Main(string[] args)
        {
            decimal a = -5;
            decimal b = -4;
            decimal c = -2;
            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine(a); 
                }
                else
                {
                    Console.WriteLine(c);
                }
            }
            else
            {
                if (b > c)
                {
                    Console.WriteLine(b);
                }
                else
                {
                    Console.WriteLine(c);
                }
            }
        }
    }
}
