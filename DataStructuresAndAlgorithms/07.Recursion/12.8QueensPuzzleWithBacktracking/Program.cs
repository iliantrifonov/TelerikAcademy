namespace _12._8QueensPuzzleWithBacktracking
{
    using System;
    using System.Linq;

    /// <summary>
    /// * Write a recursive program to solve the "8 Queens Puzzle" with backtracking. Learn more at: http://en.wikipedia.org/wiki/Eight_queens_puzzle
    /// </summary>
    public class Program
    {
        private const int Size = 8;
        private const int Offset = 2 * Size;
        private static bool[] usedCols = new bool[Size];
        private static bool[] usedDiagsonal = new bool[4 * Size];
        private static int count = 0;

        internal static void Main(string[] args)
        {
            SolveQueens(0, new int[Size]);
            Console.WriteLine(count);
        }

        private static void SolveQueens(int row, int[] queens)
        {
            for (int col = 0; col < Size; col++)
            {
                if (!usedCols[col] && !usedDiagsonal[row - col + Size] && !usedDiagsonal[row + col + Offset])
                {
                    queens[row] = col;

                    usedCols[col] = true;
                    usedDiagsonal[row - col + Size] = true;
                    usedDiagsonal[row + col + Offset] = true;

                    if (row == Size - 1)
                    {
                        count++;
                    }
                    else
                    {
                        SolveQueens(row + 1, queens);
                    }

                    usedCols[col] = false;
                    usedDiagsonal[row - col + Size] = false;
                    usedDiagsonal[row + col + Offset] = false;
                }
            }
        }
    }
}
