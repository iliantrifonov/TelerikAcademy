namespace _08.To10.MatrixImplimentation
{
    using System;
    //8.Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
    //9.Implement an indexer this[row, col] to access the inner matrix cells.
    //10.Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).

    public class Matrix<T>
    {
        private T[,] array;

        public Matrix(int rows, int cols)
        {
            this.array = new T[rows, cols];
            this.GetRows = rows;
            this.GetCollumns = cols;
        }

        public int GetRows
        {
            get;
            private set;
        }

        public int GetCollumns
        {
            get;
            private set;
        }

        public T this[int row, int col]
        {
            get
            {
                return this.array[row, col];
            }
            set
            {
                if (value is T)
                {
                    this.array[row, col] = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetRows != secondMatrix.GetRows || firstMatrix.GetCollumns != secondMatrix.GetCollumns)
            {
                throw new IndexOutOfRangeException("The matrixes are of different size !");
            }
            Matrix<T> result = new Matrix<T>(firstMatrix.GetRows, firstMatrix.GetCollumns);
            for (int i = 0; i < firstMatrix.GetRows; i++)
            {
                for (int j = 0; j < firstMatrix.GetCollumns; j++)
                {
                    result[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetRows != secondMatrix.GetRows || firstMatrix.GetCollumns != secondMatrix.GetCollumns)
            {
                throw new IndexOutOfRangeException("The matrixes are of different size !");
            }
            Matrix<T> result = new Matrix<T>(firstMatrix.GetRows, firstMatrix.GetCollumns);
            for (int i = 0; i < firstMatrix.GetRows; i++)
            {
                for (int j = 0; j < firstMatrix.GetCollumns; j++)
                {
                    result[i, j] = (dynamic)firstMatrix[i, j] - (dynamic)secondMatrix[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetRows != secondMatrix.GetRows || firstMatrix.GetCollumns != secondMatrix.GetCollumns)
            {
                throw new IndexOutOfRangeException("The matrixes are of different size !");
            }
            Matrix<T> result = new Matrix<T>(firstMatrix.GetRows, firstMatrix.GetCollumns);

            for (int row = 0; row < firstMatrix.GetRows; row++)
            {
                for (int col = 0; col < firstMatrix.GetCollumns; col++)
                {
                    dynamic currentSum = 0;
                    for (int coll = 0; coll < firstMatrix.GetCollumns; coll++)
                    {
                        currentSum += (dynamic)firstMatrix[row, coll] * (dynamic)secondMatrix[coll, col];
                    }
                    result[row, col] = currentSum;
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            dynamic zero = 0;
            for (int i = 0; i < matrix.GetRows; i++)
            {
                for (int j = 0; j < matrix.GetCollumns; j++)
                {
                    if ((dynamic)matrix[i, j] == zero)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            dynamic zero = 0;
            for (int i = 0; i < matrix.GetRows; i++)
            {
                for (int j = 0; j < matrix.GetCollumns; j++)
                {
                    if ((dynamic)matrix[i, j] == zero)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
