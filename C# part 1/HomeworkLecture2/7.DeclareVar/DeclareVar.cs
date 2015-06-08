using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.DeclareVar
{
    class DeclareVar
    {
        static void Main(string[] args)
        {
            string a = "Hello";
            string b = "World";
            object c = a + " " + b;
            string str = (string)c;
            Console.WriteLine(str);
        }
    }
}
