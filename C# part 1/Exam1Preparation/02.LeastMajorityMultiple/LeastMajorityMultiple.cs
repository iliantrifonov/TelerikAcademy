using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LeastMajorityMultiple
{
    class LeastMajorityMultiple
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            long number = 1;
            while (true)
            {
                int count = 0;
                if (number % a == 0)
                {
                    count++;
                }
                if (number % b == 0)
                {
                    count++;
                }
                if (number % c == 0)
                {
                    count++;
                }
                if (number % d == 0)
                {
                    count++;
                }
                if (number % e == 0)
                {
                    count++;
                }
                if (count >= 3)
                {
                    break;
                }
                number++;
            }
            Console.WriteLine(number);
        }
    }
}
