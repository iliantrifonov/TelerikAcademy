using System;

namespace _01.PrintMatrixA
{
    class PrintMatrixA
    {
        static void Main(string[] args)
        {
            //Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)

            Console.WriteLine("Enter size N:");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int startNumber = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = startNumber;
                    startNumber++;
                }
            }
            Console.WriteLine("This is A)");
            PrintMatrix(matrix);
            Console.WriteLine();

            // for B)

            startNumber = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if ((col & 1) == 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = startNumber;
                        startNumber++;
                    } 
                }
                else
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        matrix[row, col] = startNumber;
                        startNumber++;
                    } 
                }
            }
            Console.WriteLine("This is B)");
            PrintMatrix(matrix);
            Console.WriteLine();

            //for C)
            int rows = matrix.GetLength(0) - 1;
            int cols = 0;
            startNumber = 1;
            int curRows = matrix.GetLength(0) - 1;
            int curCols = 0;

            for (int i = 0; i < matrix.GetLength(0) * matrix.GetLength(1); i++)
            {
                matrix[rows, cols] = startNumber;
                startNumber++;
                if (rows < matrix.GetLength(0) - 1 && cols < matrix.GetLength(1) - 1)
                {
                    rows++;
                    cols++;
                    continue;
                }
                else
                {
                    if (curRows > 0)
                    {
                        cols = 0;
                        curRows--;
                        rows = curRows;
                    }
                    else
                    {
                        rows = 0;
                        curCols++;
                        cols = curCols;
                    }
                }
            }

            Console.WriteLine("This is C)");
            PrintMatrix(matrix);
            Console.WriteLine();

            // for D)
            // clear matrix 
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = -1;
                }
            }

            rows = 0;
            cols = 0;
            startNumber = 1;
            string direction = "down";
            for (int i = 0; i < matrix.GetLength(0) * matrix.GetLength(1); i++)
            {
                if (direction == "down")
                {
                    matrix[rows, cols] = startNumber;
                    if (rows + 1 == matrix.GetLength(0) || matrix[rows + 1,cols] != -1)
                    {
                        direction = "right";
                        cols++;
                    }
                    else
                    {
                        rows++;
                    }
                }
                else if (direction == "right")
                {
                    matrix[rows, cols] = startNumber;
                    if (cols + 1 == matrix.GetLength(1) || matrix[rows, cols + 1] != -1)
                    {
                        direction = "up";
                        rows--;
                    }
                    else
                    {
                        cols++;
                    }
                }
                else if (direction == "up")
                {
                    matrix[rows, cols] = startNumber;
                    if (rows - 1 == -1 || matrix[rows - 1, cols] != -1)
                    {
                        direction = "left";
                        cols--;
                    }
                    else
                    {
                        rows--;
                    }
                }
                else if (direction == "left")
                {
                    matrix[rows, cols] = startNumber;
                    if (cols - 1 == -1 || matrix[rows, cols - 1] != -1)
                    {
                        direction = "down";
                        rows++;
                    }
                    else
                    {
                        cols--;
                    }
                }
                startNumber++;
            }
            Console.WriteLine("This is D)");
            PrintMatrix(matrix);
            Console.WriteLine();
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
