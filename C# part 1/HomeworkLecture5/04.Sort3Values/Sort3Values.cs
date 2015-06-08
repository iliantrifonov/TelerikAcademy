using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sort3Values
{
    class Sort3Values
    {
        static void Main(string[] args)
        {
            // 3 different numbers
            decimal a = 11;
            decimal b = 3;
            decimal c = 5;
            decimal largestNum = 0;
            if (a > b)
            {
                if (a > c)
                {
                    largestNum = a;
                }
                else
                {
                    largestNum = c;
                }
            }
            else
            {
                if (b > c)
                {
                    largestNum = b;
                }
                else
                {
                    largestNum = c;
                }
            }

            decimal smallestNum = 0;
            if (a < b)
            {
                if (a < c)
                {
                    smallestNum = a;
                }
                else
                {
                    smallestNum = c;
                }
            }
            else
            {
                if (b < c)
                {
                    smallestNum = b;
                }
                else
                {
                    smallestNum = c;
                }
            }

            
            if (a != smallestNum && a != largestNum)
            {
                Console.WriteLine("{0}, {1}, {2}", largestNum, a, smallestNum);
            }
            else if (b != smallestNum && b != largestNum)
            {
                Console.WriteLine("{0}, {1}, {2}", largestNum, b, smallestNum);
            }
            else
            {
                Console.WriteLine("{0}, {1}, {2}", largestNum, c, smallestNum);
            }
        }
    }
}
