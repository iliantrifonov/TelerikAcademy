using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.TwoGirls1Path
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long[] arrayOfNums = new long[input.Length];
            for (int i = 0; i < arrayOfNums.Length; i++)
            {
                arrayOfNums[i] = long.Parse(input[i]);
            }
            bool isEmptyMolly = false;
            bool isEmptyDolly = false;
            BigInteger Molly = 0;
            BigInteger Dolly = 0;
            long indexMolly = 0;
            long indexDolly = arrayOfNums.Length - 1;
            long mollyMove = 0;
            long dollyMove = 0;
            while (isEmptyDolly == false && isEmptyMolly == false)
            {
                if (indexDolly < 0)
                {
                    long temp = (indexDolly * -1) % arrayOfNums.Length;
                    temp *= -1;
                    indexDolly = temp + arrayOfNums.Length;
                }
                if (indexMolly >= arrayOfNums.Length)
                {
                    indexMolly %= arrayOfNums.Length;
                }
                if (arrayOfNums[indexMolly] == 0)
                {
                    isEmptyMolly = true;
                }
                if (arrayOfNums[indexDolly] == 0)
                {
                    isEmptyDolly = true;
                }
                if (indexDolly == indexMolly)
                {
                    mollyMove = arrayOfNums[indexMolly] / 2;
                    dollyMove = mollyMove;
                    arrayOfNums[indexMolly] = (arrayOfNums[indexMolly] & 1);
                    
                }
                else
                {
                    mollyMove = arrayOfNums[indexMolly];
                    dollyMove = arrayOfNums[indexDolly];
                    arrayOfNums[indexMolly] = 0;
                    arrayOfNums[indexDolly] = 0;
                }
                
                Molly += mollyMove;
                Dolly += dollyMove;
                indexDolly -= dollyMove;
                indexMolly += mollyMove;
                
            }
            if (isEmptyDolly == false)
            {
                Console.WriteLine("Dolly");
            }
            else if (isEmptyMolly == false)
            {
                Console.WriteLine("Molly");
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.WriteLine("{0} {1}", Molly, Dolly);
        }
    }
}
