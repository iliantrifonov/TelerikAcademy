using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ShowSignWithoutCalc
{
    class ShowSignWithoutCalc
    {
        static void Main(string[] args)
        {
            decimal a = 3;
            decimal b = 4;
            decimal c = 5;
            if (a > 0 && b > 0 && c > 0)
            {
                Console.WriteLine("+");
            }
            if (a < 0 && b > 0 && c > 0)
            {
                Console.WriteLine("-");
            }
            if (a > 0 && b < 0 && c > 0)
            {
                Console.WriteLine("-");
            }
            if (a > 0 && b > 0 && c < 0)
            {
                Console.WriteLine("-");
            }
            if (a < 0 && b < 0 && c > 0)
            {
                Console.WriteLine("+");
            }
            if (a < 0 && b > 0 && c < 0)
            {
                Console.WriteLine("+");
            }
            if (a > 0 && b < 0 && c < 0)
            {
                Console.WriteLine("+");
            }
            if (a < 0 && b < 0 && c < 0)
            {
                Console.WriteLine("-");
            }
        }
    }
}
