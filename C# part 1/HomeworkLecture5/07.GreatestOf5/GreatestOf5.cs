using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GreatestOf5
{
    class GreatestOf5
    {
        static void Main(string[] args)
        {
            int a = 7;
            int b = 3;
            int c = -4;
            int d = 12;
            int z = 11;
            Console.WriteLine(Math.Max(a, (Math.Max(b, Math.Max(c, Math.Max(d, z))))));
        }
    }
}
