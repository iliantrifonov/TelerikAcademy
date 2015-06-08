using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SevenlandNumbers
{
    class SevenlandNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            a += 1;
            int[] array = { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                if (a % 10 < 7)
                {
                    array[i] = a % 10;
                    a /= 10;
                }
                else
                {
                    array[i] = 0;
                    a /= 10;
                    a++;
                }
            }
            string str = "";
            for (int i = 3; i >= 0; i--)
            {
                str += array[i];
            }
            Console.WriteLine(int.Parse(str));
        }
    }
}
