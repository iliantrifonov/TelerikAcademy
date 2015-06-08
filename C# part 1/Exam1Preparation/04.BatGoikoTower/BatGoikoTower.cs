using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BatGoikoTower
{
    class BatGoikoTower
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 2;
            int countRow = 2;
            bool isMet = false;
            for (int i = 1; i <= n; i++)
            {
                isMet = false;
                for (int i2 = 1; i2 <= n * 2; i2++)
                {
                    if (i2 == ( n - i + 1 ))
                    {
                        Console.Write("/");
                    }
                    else if (i2 == ( n + i ))
                    {
                        Console.Write(@"\");
                    }
                    else if ((i2 > (n - i + 1) && i2 < (n + i)) && counter == i)
                    {
                        Console.Write("-");
                        isMet = true;
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                if (isMet)
                {
                    counter += countRow;
                    countRow++;
                }
                Console.WriteLine();
            }
        }
    }
}
