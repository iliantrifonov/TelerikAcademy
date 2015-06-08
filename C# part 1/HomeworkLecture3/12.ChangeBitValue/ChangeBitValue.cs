using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ChangeBitValue
{
    class ChangeBitValue
    {
        static void Main(string[] args)
        {
            int num = 21;
            int position = 4;
            int value = 0;
            if (value == 1)
            {
                num = (1 << position) | num;
                Console.WriteLine(num);
            }
            else if (value == 0)
            {
                num = (~(1 << position)) & num;
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }
    }
}
