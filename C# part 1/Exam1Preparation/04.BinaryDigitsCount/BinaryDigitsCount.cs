using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BinaryDigitsCount
{
    class BinaryDigitsCount
    {
        static void Main(string[] args)
        {
            int b = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                uint number = uint.Parse(Console.ReadLine());
                int count = 0;
                while (number > 0)
                {
                    if ((number & 1) == b)
                    {
                        count++;
                    }
                    number = number >> 1;
                }
                Console.WriteLine(count);
            }
        }
    }
}
