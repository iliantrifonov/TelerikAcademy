namespace _08.To10.MatrixImplimentation
{
    using System;
    public class TextMatrices
    {
        public static void Main(string[] args)
        {
            Matrix<int> matrix = new Matrix<int>(3,2);
            Matrix<int> secondMatrix = new Matrix<int>(3,2);
            for (int i = 0; i < matrix.GetRows; i++)
            {
                for (int j = 0; j < matrix.GetCollumns; j++)
                {
                    matrix[i, j] = i + j;
                    secondMatrix[i, j] = i + j;
                }
            }
            Matrix<int> sum = matrix + secondMatrix;
            Matrix<int> minus = matrix - secondMatrix;
            Matrix<int> multiply = matrix * secondMatrix;
            if (matrix)
            {
                Console.WriteLine("There is a no zero element in matrix");
            }
            else
            {
                Console.WriteLine("There is a zero element in matrix");
            }

        }
    }
}
