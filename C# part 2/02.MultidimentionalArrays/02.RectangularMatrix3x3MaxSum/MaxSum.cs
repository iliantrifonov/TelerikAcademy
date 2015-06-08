using System;

namespace _02.RectangularMatrix3x3MaxSum
{
    class MaxSum
    {
        static void Main(string[] args)
        {
            //Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

            Console.WriteLine("Enter N above 3: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter M above 3: ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }

            //int[,] matrix = 
            //{
            //    {1, 2, 3, 4, 5, 6}, 
            //    {5, 6, 7, 8, 9 , 10}, 
            //    {1, 2, 3, 4, 5, 6},
            //    {1, 2, 3, 4, 5, 6}
            //};

            int maxSum = int.MinValue;
            string maxMembers = "";
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row + 1, col] + matrix[row + 2, col] + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 2, col + 1] + matrix[row, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxMembers = matrix[row, col] + " " + matrix[row + 1, col] + " " + matrix[row + 2, col] + " " + matrix[row, col + 1] + " " + matrix[row + 1, col + 1] + " " + matrix[row + 2, col + 1] + " " + matrix[row, col + 2] + " " + matrix[row + 1, col + 2] + " " + matrix[row + 2, col + 2];
                    }
                }
            }
            Console.WriteLine("The sum is {0}, from numbers: {1}", maxSum, maxMembers);
        }
    }
}
