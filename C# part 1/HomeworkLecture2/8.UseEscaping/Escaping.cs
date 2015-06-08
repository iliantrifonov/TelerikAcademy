using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.UseEscaping
{
    class Escaping
    {
        static void Main(string[] args)
        {
            string a = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(a);
            string b = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(b);
        }
    }
}
