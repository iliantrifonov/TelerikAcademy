using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N:");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];// I cant think of a way of doing this without a matrix ( 2d array )
            int pos = 1;  //here we input a "starting number" for the matrix, in this case 1
            int count = n; //counter for the numbers, so when it gets to 0 it ends the cicle
            int value = -n;
            int sum = -1;
            do
            {
                value = -1 * value / n; //indea is on every "turn" it will change direction ( from up to down, from left to right etc )
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    matrix[sum / n, sum % n] = pos++;
                }
                value *= n;//by doing this it start "going" from the rows to the cols
                count--;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    matrix[sum / n, sum % n] = pos++;
                }
            } while (count > 0);
            //This will print the matrix
            for (int row = 0; row < matrix.GetLength(0); row++) 
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 4}", matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
