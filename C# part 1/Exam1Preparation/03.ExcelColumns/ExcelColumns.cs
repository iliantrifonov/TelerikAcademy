using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ExcelColumns
{
    class ExcelColumns
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            long result = 0;
            long power = (long)Math.Pow(26, num - 1);
            for (int i = num; i >= 1; i--)
            {
                char letter = char.Parse(Console.ReadLine());
                result += (letter - 'A' + 1) * power;
                power /=26;
            }
            Console.WriteLine(result);
        }
    }
}
