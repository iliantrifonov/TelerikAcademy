using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.IntWithNull
{
    class IntAndDoubleWithNull
    {
        static void Main(string[] args)
        {
            int? a = null;
            double? b = null;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(a + null); //always null
            int c = a.GetValueOrDefault() + 5;
            Console.WriteLine(c);
        }
    }
}
