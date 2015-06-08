using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.DividedWithoutRemainderWith7And5
{
    class DivededWithoutRemainder
    {
        static void Main(string[] args)
        {
            int num = 5*7;
            if ((num % 7) == 0 && (num % 5) == 0)
            {
                Console.WriteLine("Number can be divided without remainder by 7 and 5"); 
            }
            else
            {
                Console.WriteLine("Number CANNOT be divided without remainder by 7 and 5"); 

            }
        }
    }
}
