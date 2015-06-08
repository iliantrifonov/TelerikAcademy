using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WeAllLoveBits
{
    class WeAllLoveBits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int invertedNum = 0;
            int revNum = 0;
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                int counter = 0;
                while (number >> counter != 0)
                {
                    if (((number >> counter) & 1) == 0)
                    {
                        invertedNum = (1 << counter) | invertedNum;
                    }
                    counter++;
                }
                counter = 0;
                while (number >> counter != 0)
                {
                    counter++;
                }
                int secCount = 0;
                while (counter > 0)
                {
                    if (((number >> (counter - 1)) & 1) == 0)
	                {
		 
	                }
                    else
                    {
                        revNum = (1 << secCount) | revNum;
                    }
                    counter--;
                    secCount++;
                }
                int newNum = (number ^ invertedNum) & revNum;
                Console.WriteLine(newNum);
                counter = 0;
                secCount = 0;
                invertedNum = 0;
                revNum = 0;
            }
        }
    }
}
