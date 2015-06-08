using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TrippleRotationOfDigits
{
    class TrippleRotationOfDigits
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                long lastNum = number % 10;
                if (number / 10 == 0)
                {
                    break;
                }
                number /= 10;
                
                string strNumber = lastNum.ToString() + number.ToString();
                number = long.Parse(strNumber);
            }
            Console.WriteLine(number);
        }
    }
}
