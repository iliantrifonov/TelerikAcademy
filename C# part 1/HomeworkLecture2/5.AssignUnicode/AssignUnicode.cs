using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.AssignUnicode
{
    class AssignUnicode
    {
        static void Main(string[] args)
        {
            //I'm checking the hexadecimal representation
            int a = 72;
            Console.WriteLine("{0:X}", a);
            char letter = '\u0048';
            Console.WriteLine(letter);
        }
    }
}
