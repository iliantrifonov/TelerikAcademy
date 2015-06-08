using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _05.NxKdivN_K
{
    class NxKdivNminusK
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 < N < K ");
            Console.WriteLine("Please input K");
            int kk = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input N");
            int nn = int.Parse(Console.ReadLine());
            if (1 < nn && nn < kk)
            {
                int a = kk - nn;
                BigInteger factorialKK = 1;
                BigInteger factorialNN = 1;
                BigInteger factorialA = 1;
                for (int i = 1; i <= kk; i++)
                {
                    factorialKK *= i;
                }
                for (int i = 1; i <= nn; i++)
                {
                    factorialNN *= i;
                }
                for (int i = 1; i <= a; i++)
                {
                    factorialA *= i;
                }
                Console.WriteLine((factorialKK * factorialNN) / factorialA);
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }
    }
}
