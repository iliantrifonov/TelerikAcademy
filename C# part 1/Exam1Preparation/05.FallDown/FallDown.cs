using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FallDown
{
    class FallDown
    {
        static void Main(string[] args)
        {
            int[] numArray = new int[8];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = int.Parse(Console.ReadLine());
            }
            int[] result = DropBits(numArray);

            for (int i = result.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(result[i]);
            }

        }
        private static int[] DropBits(int[] array) 
        {
            int[] resultArr = new int[array.Length];
            for (int i = 0; i < resultArr.Length; i++)
            {
                resultArr[i] = array[i];
            }
            for (int i = 0; i < resultArr.Length; i++)
            {
                int k = i;
                while (k > 0)
                {
                    
                    int tempResult = resultArr[k] & resultArr[k - 1];
                    resultArr[k - 1] = resultArr[k] | resultArr[k - 1];
                    resultArr[k] = tempResult;
                    k--;
                }
            }
            return resultArr;
        }
    }
}
