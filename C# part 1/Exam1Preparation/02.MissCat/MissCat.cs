using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MissCat
{
    class MissCat
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[11];
            for (int i = 0; i < n; i++)
            {
                int cat = int.Parse(Console.ReadLine());
                arr[cat]++;
            }
            int max = -1;
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    result = i;
                }
            }
            Console.WriteLine(result);
        }
    }
}
