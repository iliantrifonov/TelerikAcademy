
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _04.DancingBits
{
    class DancingBits
    {
        static void Main(string[] args)
        {

            int K = int.Parse(Console.ReadLine());

            int N = int.Parse(Console.ReadLine());

            string result = "";
            for (int i = 0; i < N; i++)
            {
                int number = int.Parse(Console.ReadLine());

                result += Convert.ToString(number, 2);

            }

            int count = 0;
            int endResult = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (i != 0 && result[i] == result[i - 1])
                {
                    count++;
                }
                else
                {
                    if (count == K)
                    {
                        endResult++;
                    }
                    count = 1;
                }
            }
            if (count == K)
            {
                endResult++;
            }
            Console.WriteLine(endResult);
        }
    }
}
