using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.NFibonacci
{
    class NFibonacci
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter N:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Fibonacci :");
            int firstNum = 0;
            int secondNum = 1;
            Console.Write(firstNum);
            Console.Write(", " + secondNum);
            for (int i = 0; i < n - 2; i++)
            {
                int c;
                c = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = c;
                Console.Write(", " + c); 
            }
            Console.WriteLine();
        }
    }
}
