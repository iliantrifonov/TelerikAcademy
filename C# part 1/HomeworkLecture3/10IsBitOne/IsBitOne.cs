using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10IsBitOne
{
    class IsBitOne
    {
        static void Main(string[] args)
        {
            int num = 5;
            int position = 1;
            if (((num >> position) & 1) == 1)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
