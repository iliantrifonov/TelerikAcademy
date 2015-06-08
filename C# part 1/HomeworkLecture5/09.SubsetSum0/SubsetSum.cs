using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SubsetSum0
{
    class SubsetSum
    {
        static void Main(string[] args)
        {
            //enter numbers in the array
            int[] array = { 1, 2, 3, 4, -10 };
            for (int i1 = 0; i1 < array.Length; i1++)
            {
                if (array[i1] == 0)
                {
                    Console.WriteLine(array[i1] + " = 0");
                }
                for (int i2 = i1 + 1; i2 < array.Length; i2++)
                {
                    if (array[i1] + array[i2] == 0)
                    {
                        Console.WriteLine("({0}) + ({1}) = 0", array[i1], array[i2]);
                    }
                    for (int i3 = i2 + 1; i3 < array.Length; i3++)
                    {
                        if (array[i1] + array[i2] + array[i3] == 0)
                        {
                            Console.WriteLine("({0}) + ({1}) + ({2}) = 0", array[i1], array[i2], array[i3]);
                        }
                        for (int i4 = i3 + 1; i4 < array.Length; i4++)
                        {
                            if (array[i1] + array[i2] + array[i3] + array[i4] == 0)
                            {
                                Console.WriteLine("({0}) + ({1}) + ({2}) + ({3}) = 0", array[i1], array[i2], array[i3], array[i4]);
                            }
                            for (int i5 = i4 + 1; i5 < array.Length; i5++)
                            {
                                if (array[i1] + array[i2] + array[i3] + array[i4] + array[i5] == 0)
                                {
                                    Console.WriteLine("({0}) + ({1}) + ({2}) + ({3}) + ({4}) = 0", array[i1], array[i2], array[i3], array[i4], array[i5]);
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}