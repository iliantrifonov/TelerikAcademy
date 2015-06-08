using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GDC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 2 integers:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;  
                }
                else
                {
                    b %= a;
                }
            }
            Console.WriteLine("Greatest common divider is:");
            if (a == 0)
            {
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine(a);
            }
        }
    }
}
