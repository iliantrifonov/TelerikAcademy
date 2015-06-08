using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._1ToNNotDivisble3And7
{
    class OneToNNotDivisble3And7
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter N:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if ((i % 3 == 0) && (i % 7 == 0))
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}
