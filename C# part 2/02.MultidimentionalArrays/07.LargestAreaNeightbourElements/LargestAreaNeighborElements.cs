using System;

namespace _07.LargestAreaNeightbourElements
{
    class LargestAreaNeighborElements
    {
        //* Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size. Example:

        static int member = 0;
        static int counter = 0;
        static int currentNumber = 0;
        static int[,] numArray =
        {
            {1, 3, 3, 2, 3, 1, 3},
            {2, 2, 2, 2, 2, 2, 2},
            {3, 3, 3, 2, 3, 3, 1},
            {1, 2, 2, 2, 2, 2, 3},
            {3, 1, 3, 1, 3, 1, 1},
        };

        static void FindExit(int row, int col)//recursive method
        {
            if ((col < 0) || (row < 0) || (col >= numArray.GetLength(1)) || (row >= numArray.GetLength(0)))
            {
                // we are out of the matrix
                return;
            }

            if (numArray[row, col] == int.MinValue)
            {
                // the current cell is already visited
                return;
            }
            currentNumber = numArray[row, col];
            // mark the current cell as visited
            numArray[row, col] = int.MinValue;
            // recursion to explore all possible directions
            if (col - 1 >= 0 && numArray[row, col - 1] == currentNumber)
            {
                FindExit(row, col - 1); // left
            }
            if (row - 1 >= 0 && numArray[row - 1, col] == currentNumber)
            {
                FindExit(row - 1, col); // up
            }
            if (col + 1 < numArray.GetLength(1) && numArray[row, col + 1] == currentNumber)
            {
                FindExit(row, col + 1); // right
            }
            if (row + 1 < numArray.GetLength(0) && numArray[row + 1, col] == currentNumber)
            {
                FindExit(row + 1, col); // down
            }

            counter++;
            return;
        }

        static void Main(string[] args)
        {
            int finalCount = 0;
            int maxSequenceMember = 0;

            for (int row = 0; row < numArray.GetLength(0); row++)
            {
                for (int col = 0; col < numArray.GetLength(1); col++)
                {
                    if (numArray[row, col] != int.MinValue)
                    {
                        counter = 0;
                        member = numArray[row, col];
                        bool checker = false;
                        FindExit(row, col);
                        if (finalCount < counter)
                        {
                            finalCount = counter;
                            checker = true;
                            if (checker == true)
                            {
                                maxSequenceMember = member;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("The largest area of equal neighbor elements is {0}", finalCount);
            Console.WriteLine("The element is {0}", maxSequenceMember);
        }
    }
}
