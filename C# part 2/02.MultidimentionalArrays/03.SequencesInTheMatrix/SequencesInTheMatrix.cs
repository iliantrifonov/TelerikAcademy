using System;

namespace _03.SequencesInTheMatrix
{
    class SequencesInTheMatrix
    {
        static void Main(string[] args)
        {
            //We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix. Example:
            Console.WriteLine("Enter N");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter M");
            int m = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, m];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = Console.ReadLine();
                }
            }
            //string[,] matrix = 
            //{
            //    {"pp", "qq", "s"},
            //    {"pp", "s", "z"},
            //    {"s", "qq", "pp"},
            //};

            int maxNumberOfElements = 0;
            string maxElement = "";
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int horizontal = HorizontalMaxLenghtOfEqualElements(matrix, row, col);
                    if (maxNumberOfElements < horizontal)
                    {
                        maxNumberOfElements = horizontal;
                        maxElement = matrix[row, col];
                    }
                    int vertical = VerticalMaxLenghtOfEqualElements(matrix, row, col);
                    if (maxNumberOfElements < vertical)
                    {
                        maxNumberOfElements = vertical;
                        maxElement = matrix[row, col];
                    }
                    int diagonalLeft = DiagonalLeftLenghtOfEqualElements(matrix, row, col);
                    if (maxNumberOfElements < diagonalLeft)
                    {
                        maxNumberOfElements = diagonalLeft;
                        maxElement = matrix[row, col];
                    }
                    int diagonalRight = DiagonalRightLenghtOfEqualElements(matrix, row, col);
                    if (maxNumberOfElements < diagonalRight)
                    {
                        maxNumberOfElements = diagonalRight;
                        maxElement = matrix[row, col];
                    }
                }
            }
            Console.WriteLine("The maximal sequence is:");
            for (int i = 0; i < maxNumberOfElements; i++)
            {
                Console.Write(maxElement + " ");
            }
            Console.WriteLine();
        }

        static int HorizontalMaxLenghtOfEqualElements(string[,] matrix, int row, int col) 
        {
            string keyValue = matrix[row, col];
            int numberOfElements = 0;
            while (col < matrix.GetLength(1))
            {
                if (keyValue == matrix[row,col])
                {
                    numberOfElements++;
                }
                else
                {
                    break;
                }
                col++;
            }
            return numberOfElements;
        }

        static int VerticalMaxLenghtOfEqualElements(string[,] matrix, int row, int col)
        {
            string keyValue = matrix[row, col];
            int numberOfElements = 0;
            while (row < matrix.GetLength(0))
            {
                if (keyValue == matrix[row, col])
                {
                    numberOfElements++;
                }
                else
                {
                    break;
                }
                row++;
            }
            return numberOfElements;
        }

        static int DiagonalRightLenghtOfEqualElements(string[,] matrix, int row, int col)
        {
            string keyValue = matrix[row, col];
            int numberOfElements = 0;
            while (row < matrix.GetLength(0) && col < matrix.GetLength(1))
            {
                if (keyValue == matrix[row, col])
                {
                    numberOfElements++;
                }
                else
                {
                    break;
                }
                row++;
                col++;
            }
            return numberOfElements;
        }

        static int DiagonalLeftLenghtOfEqualElements(string[,] matrix, int row, int col)
        {
            string keyValue = matrix[row, col];
            int numberOfElements = 0;
            while (row < matrix.GetLength(0) && col >= 0)
            {
                if (keyValue == matrix[row, col])
                {
                    numberOfElements++;
                }
                else
                {
                    break;
                }
                row++;
                col--;
            }
            return numberOfElements;
        }
    }
}
