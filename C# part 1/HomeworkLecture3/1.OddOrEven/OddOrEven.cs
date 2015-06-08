using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.OddOrEven
{
    class OddOrEven
    {
        static void Main(string[] args)
        {
            int num = 5;
            if ((num & 1) == 1)
            {
                Console.WriteLine("Number is odd");
            }
            else
            {
                Console.WriteLine("Number is even");
            }
        }
    }
}
