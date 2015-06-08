using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.QuadronacciRectangle
{
    class QuadronacciRectangle
    {
        static void Main(string[] args)
        {
            long firstNum = long.Parse(Console.ReadLine());
            long secondNum = long.Parse(Console.ReadLine());
            long thirdNum = long.Parse(Console.ReadLine());
            long fourthNum = long.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int amountOfNums = rows * cols;
            long[] array = new long[amountOfNums];
            array[0] = firstNum;
            array[1] = secondNum;
            array[2] = thirdNum;
            array[3] = fourthNum;

            for (int i = 4; i < amountOfNums; i++)
            {
                long lastNum = firstNum + secondNum + thirdNum + fourthNum;
                array[i] = lastNum;
                firstNum = secondNum;
                secondNum = thirdNum;
                thirdNum = fourthNum;
                fourthNum = lastNum;

            }
            long[,] matrix = new long[rows, cols];
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < cols; k++)
                {
                    matrix[i, k] = array[counter];
                    counter++;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < cols; k++)
                {
                    Console.Write(matrix[i, k]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
    }
}
