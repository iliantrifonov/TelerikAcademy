using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReadNReturnMinAndMax
{
    class ReadNReturnMinAndMax
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter N:");
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < min)
                {
                    min = num;
                }
                if (num > max)
                {
                    max = num; 
                }
            }
            Console.WriteLine("The min value is {0}, and the max value is {1}", min, max);
        }
    }
}
