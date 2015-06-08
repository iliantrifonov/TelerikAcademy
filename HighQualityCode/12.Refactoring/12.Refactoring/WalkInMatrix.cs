namespace _12.Refactoring
{
    using System;
    using System.Text;

    public class WalkInMatrix
    {
        private readonly int[] directionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private readonly int[] directionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private readonly int[,] matrix;
        private bool isGenerated;

        public WalkInMatrix(int size)
        {
            if (size > 100 || size < 1)
            {
                throw new ArgumentException("The size of the matrix must be between 1 and 100.");
            }

            this.matrix = new int[size, size];
            this.isGenerated = false;
        }

        public int[,] GetMatrix()
        {
            if (!this.isGenerated)
            {
                this.GenerateMatrix();
            }

            int[,] matrixDeepCopy = new int[this.matrix.GetLength(0), this.matrix.GetLength(1)];

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    matrixDeepCopy[i, j] = this.matrix[i, j];
                }
            }

            return matrixDeepCopy;
        }

        public override string ToString()
        {
            if (!this.isGenerated)
            {
                this.GenerateMatrix();
            }

            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    sb.AppendFormat("{0,2}", this.matrix[row, col]);
                }

                sb.Append("\r\n");
            }

            return sb.ToString();
        }

        private void GenerateMatrix()
        {
            int k = 1;
            while (this.HasEmptyCell())
            {
                int row = 0;
                int col = 0;
                int moveDirectionRow = 1;
                int moveDirectionCol = 1;
                ICoordinate emptyCoordinate = this.GetFirstEmptyCoordinate();
                row = emptyCoordinate.Row;
                col = emptyCoordinate.Col;
                this.matrix[row, col] = k;
                while (this.HasDirectionAvailable(row, col))
                {
                    if (this.IsOutsideMatrix(row + moveDirectionRow, col + moveDirectionCol) || this.matrix[row + moveDirectionRow, col + moveDirectionCol] != 0)
                    {
                        while (this.IsOutsideMatrix(row + moveDirectionRow, col + moveDirectionCol) || this.matrix[row + moveDirectionRow, col + moveDirectionCol] != 0)
                        {
                            ICoordinate directions = this.GetNextDirection(moveDirectionRow, moveDirectionCol);
                            moveDirectionRow = directions.Row;
                            moveDirectionCol = directions.Col;
                        }
                    }

                    row += moveDirectionRow;
                    col += moveDirectionCol;
                    k++;
                    this.matrix[row, col] = k;
                }

                k++;
            }

            this.isGenerated = true;
        }

        private ICoordinate GetNextDirection(int dx, int dy)
        {
            int changeDirectionIndex = 0;
            for (int count = 0; count < 8; count++)
            {
                if (this.directionsRow[count] == dx && this.directionsCol[count] == dy)
                {
                    changeDirectionIndex = count;
                    break;
                }
            }

            if (changeDirectionIndex == 7)
            {
                dx = this.directionsRow[0];
                dy = this.directionsCol[0];
                return new Coordinate(dx, dy);
            }

            dx = this.directionsRow[changeDirectionIndex + 1];

            dy = this.directionsCol[changeDirectionIndex + 1];

            return new Coordinate(dx, dy);
        }

        private bool HasDirectionAvailable(int x, int y)
        {
            for (int i = 0; i < 8; i++)
            {
                if (!this.IsOutsideMatrix(x + this.directionsRow[i], y + this.directionsCol[i]) && this.matrix[x + this.directionsRow[i], y + this.directionsCol[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsOutsideMatrix(int row, int col)
        {
            return row < 0 || row > this.matrix.GetLength(0) - 1 || col < 0 || col > this.matrix.GetLength(1) - 1;
        }

        private ICoordinate GetFirstEmptyCoordinate()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(0); j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        return new Coordinate(i, j);
                    }
                }
            }

            throw new IndexOutOfRangeException("The matrix has no empty coordinates");
        }

        private bool HasEmptyCell()
        {
            for (int rows = 0; rows < this.matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < this.matrix.GetLength(1); cols++)
                {
                    if (this.matrix[rows, cols] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}