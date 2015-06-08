using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pillars
{
    class Pillars
    {
        static void Main(string[] args)
        {
            byte[] array = new byte[8];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = byte.Parse(Console.ReadLine());
            }

            bool foundResult = false;
            for (int i = 7; i >= 0; i--)
            {
                int sum1 = 0;
                int sum2 = 0;

                for (int row = 0; row < array.Length; row++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        if (((array[row] >> col) & 1) == 1)
                        {
                            if (col < i)
                            {
                                sum1++;
                            }
                            if (col > i)
                            {
                                sum2++;  
                            }
                        }
                    }
                }
                if (sum1 == sum2)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(sum2);
                    foundResult = true;
                    break;
                }
            }
            if (foundResult == false)
            {
                Console.WriteLine("No");
            }
        }
    }
}
