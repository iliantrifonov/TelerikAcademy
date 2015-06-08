using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.IsPrime
{
    class IsPrime
    {
        static void Main(string[] args)
        {
            int num = 37;
            int counter = 0;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    counter++; 
                }
            }
            if (counter == 0)
            {
                Console.WriteLine(num + " is prime");
            }
            else
            {
                Console.WriteLine(num + " is not prime");
            }
        }
    }
}
