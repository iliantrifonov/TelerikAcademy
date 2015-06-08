
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AngryBits
{
    class AngryBits
    {
        static void Main(string[] args)
        {
            ushort[,] matrix = new ushort[8, 16];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                ushort number = ushort.Parse(Console.ReadLine());
                for (int kk = matrix.GetLength(1) - 1; kk >= 0; kk--)
                {
                    if (((number >> kk) & 1) == 1)
                    {
                        matrix[i, matrix.GetLength(1) - kk - 1] = 1;
                    }
                }
            }
            //PrintMatrix(matrix);
            
            long score = 0;
            for (int cols = matrix.GetLength(1) / 2 - 1; cols >= 0; cols--)
            {
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    if (matrix[rows, cols] == 1)
                    {
                        //PrintMatrix(matrix);
                        matrix[rows, cols] = 0;
                        int direction = 1;
                        bool isOutUp = false;
                        bool birdOver = false;
                        int counter = 0;
                        int howManyBirdsCount = 0;
                        int rowFake = rows;
                        int colFake = cols;
                        while (true)
                        {
                            //matrix[rowFake, colFake] = 5; 
                            isOutUp = IsOutUp(matrix, colFake, rowFake, isOutUp);
                            if (isOutUp)
                            {
                                direction *= -1;
                            }
                            if ((colFake + 1 >= matrix.GetLength(1)))
                            {
                                birdOver = true;
                                break;
                            }
                            if (direction < 0 && rowFake + 1 >= matrix.GetLength(0))
                            {
                                birdOver = true;
                                break;
                            }
                            //moving
                            rowFake += (-1) * direction;
                            colFake += 1;
                            counter++;
                            if (matrix[rowFake,colFake] == 1)
                            {
                                howManyBirdsCount++;
                                matrix[rowFake, colFake] = 0;
                                if (colFake + 1 < matrix.GetLength(1))
                                {
                                    if (rowFake - 1 >= 0)
                                    {
                                        if (matrix[rowFake - 1, colFake + 1] == 1)
                                        {
                                            howManyBirdsCount++; //up right
                                            matrix[rowFake - 1, colFake + 1] = 0;
                                        }
                                    }
                                    if (matrix[rowFake, colFake + 1] == 1)
                                    {
                                        howManyBirdsCount++; // just right
                                        matrix[rowFake, colFake + 1] = 0;
                                    }
                                    if (rowFake + 1 < matrix.GetLength(0))
                                    {
                                        if (matrix[rowFake + 1, colFake + 1] == 1)
                                        {
                                            howManyBirdsCount++; //down right
                                            matrix[rowFake + 1, colFake + 1] = 0;
                                        }
                                    }
                                }
                                if (rowFake + 1 < matrix.GetLength(0))
                                {
                                    if (matrix[rowFake + 1, colFake] == 1)
                                    {
                                        howManyBirdsCount++; // just down
                                        matrix[rowFake + 1, colFake] = 0;
                                    }
                                    if (matrix[rowFake + 1, colFake - 1] == 1)
                                    {
                                        howManyBirdsCount++; // left down
                                        matrix[rowFake + 1, colFake - 1] = 0;
                                    }
                                }
                                if (matrix[rowFake, colFake - 1] == 1)
                                {
                                    howManyBirdsCount++; // just left
                                    matrix[rowFake, colFake - 1] = 0;
                                }
                                if (rowFake - 1 >= 0)
                                {
                                    if (matrix[rowFake - 1, colFake] == 1)
                                    {
                                        howManyBirdsCount++; //just up
                                        matrix[rowFake - 1, colFake] = 0;
                                    }
                                    if (matrix[rowFake - 1, colFake - 1] == 1)
                                    {
                                        howManyBirdsCount++; //left up
                                        matrix[rowFake - 1, colFake - 1] = 0;
                                    }
                                }
                                
                                score += (counter * howManyBirdsCount);
                                birdOver = true;
                                break;
                            }
                        }
                    }
                }
            }
            //PrintMatrix(matrix);
            bool playerLoses = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i,k] == 1)
                    {
                        playerLoses = true;
                    }
                }
            }
            if (playerLoses)
            {
                Console.WriteLine("{0} No", score);
            }
            if (!playerLoses)
            {
                Console.WriteLine("{0} Yes", score);
            }
        }

        private static bool IsOutUp(ushort[,] matrix, int cols, int rows, bool isOutUp)
        {
            if ((rows - 1) < 0)
            {
                isOutUp = true;
            }
            else
            {
                isOutUp = false;
            }
            return isOutUp;
        }

        private static void PrintMatrix(ushort[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[i, k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
