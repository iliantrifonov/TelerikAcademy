
using System.Text;
namespace _06.WriteClassMatrix
{
    //* Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

    class Matrix
    {
        public int dimention;
        public int[,] matrix;

        public Matrix(int size)
        {
            this.dimention = size;
            this.matrix = new int[size, size];
        }

        public int this[int row, int col]
        {
            get
            {
                return matrix[row, col];
            }
            set
            {
                matrix[row, col] = value;
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix resultMatrix = new Matrix(a.dimention);

            for (int row = 0; row < a.dimention; row++)
            {
                for (int col = 0; col < a.dimention; col++)
                {
                    resultMatrix[row, col] = a[row, col] + b[row, col];
                }
            }
            return resultMatrix;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix resultMatrix = new Matrix(a.dimention);

            for (int row = 0; row < a.dimention; row++)
            {
                for (int col = 0; col < a.dimention; col++)
                {
                    resultMatrix[row, col] = a[row, col] - b[row, col];
                }
            }
            return resultMatrix;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix resultMatrix = new Matrix(a.dimention);

            for (int row = 0; row < a.dimention; row++)
            {
                for (int col = 0; col < a.dimention; col++)
                {
                    resultMatrix[row, col] = a[row, col] * b[row, col];
                }
            }
            return resultMatrix;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this[0, 0]);
            for (int j = 1; j < this.dimention; j++)
            {
                result.AppendFormat(" {0}", this[0, j]);
            }
            for (int i = 1; i < this.dimention; i++)
            {
                result.AppendFormat("\n{0}", this[i, 0]);
                for (int j = 1; j < this.dimention; j++)
                {
                    result.AppendFormat(" {0}", this[i, j]);
                }
            }
            return result.ToString();
        }
    }
}
