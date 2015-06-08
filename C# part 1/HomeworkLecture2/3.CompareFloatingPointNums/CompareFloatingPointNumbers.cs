using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CompareFloatingPointNums
{
    class CompareFloatingPointNumbers
    {
        static void Main(string[] args)
        {
            // I am using more complex statements than necessary, can easily be done with if/else
            Console.WriteLine( 5.3f == 6.01f ? "true" : "false");
            Console.WriteLine(5.00000001f == 5.00000003f ? "true" : "false");
        }
    }
}
