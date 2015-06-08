using System.IO;

namespace _05.ReadMatrixPrintMax
{
    class Program
    {
        //Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers separated by space. The output should be a single number in a separate text file. Example:

        static void Main(string[] args)
        {
            int maxSum = 0;
            using (StreamReader matrixReader = new StreamReader(@"..\..\matrix.txt"))
            {
                string line = matrixReader.ReadLine();
                int matrixSize = int.Parse(line);
                int[,] numMatrix = new int[matrixSize, matrixSize];
                for (int row = 0; row < numMatrix.GetLength(0); row++)
                {
                    line = matrixReader.ReadLine();
                    string[] numbersInTheLine = line.Split(' ');
                    for (int col = 0; col < numMatrix.GetLength(1); col++)
                    {
                        numMatrix[row, col] = int.Parse(numbersInTheLine[col]);
                    }
                }
                maxSum = MaxSum2x2(numMatrix);
            }
            using (StreamWriter fileWriter = new StreamWriter(@"..\..\result.txt"))
            {
                fileWriter.WriteLine(maxSum);
            }
        }

        private static int MaxSum2x2(int[,] matrix)
        {
            int maxSum = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row, col + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            return maxSum;
        }
    }
}
