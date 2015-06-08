using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CoffeeVendingMachine
{
    class CoffeeVendingMachine
    {
        static void Main(string[] args)
        {
            decimal n1 = int.Parse(Console.ReadLine());
            decimal n2 = int.Parse(Console.ReadLine());
            decimal n3 = int.Parse(Console.ReadLine());
            decimal n4 = int.Parse(Console.ReadLine());
            decimal n5 = int.Parse(Console.ReadLine());
            decimal a = decimal.Parse(Console.ReadLine());
            decimal p = decimal.Parse(Console.ReadLine());

            n1 *= 0.05M;
            n2 *= 0.1M;
            n3 *= 0.2M;
            n4 *= 0.5M;
            n5 *= 1M;

            decimal moneyInside = n1 + n2 + n3 + n4 + n5;

            if (a < p)
            {
                decimal missingAmount = p - a;
                Console.WriteLine("More {0:0.00}", missingAmount);
            }
            if (a >= p)
            {
                if (moneyInside < (a - p))
                {
                    Console.WriteLine("No {0:0.00}", (a - p) - moneyInside);
                }
                else
                {
                    Console.WriteLine("Yes {0:0.00}", moneyInside - ( a - p ));
                }
            }
        }
    }
}
