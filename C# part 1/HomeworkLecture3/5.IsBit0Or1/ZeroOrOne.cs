using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.IsBit0Or1
{
    class ZeroOrOne
    {
        static void Main(string[] args)
        {
            int num = 13;
            if (((num >> 3) & 1) == 1)
            {
                Console.WriteLine("Bit on position 3 is 1");
            }
            else
            {
                Console.WriteLine("Bit on position 3 is 0");
            }
        }
    }
}
