using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.BitValue
{
    class ExtractBitValue
    {
        static void Main(string[] args)
        {
            int num = 5;
            int position = 2;
            if (((num >> position) & 1) == 1)
            {
                Console.WriteLine("Value = 1");
            }
            else
            {
                Console.WriteLine("Value = 0");
            }
        }
    }
}
