using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitBall
{
    class BitBall
    {
        static void Main(string[] args)
        {
            int[,] array = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                int number = int.Parse(Console.ReadLine());
                for (int kk = 0; kk < 8; kk++)
                {
                    if (((number >> kk) & 1) == 1)
                    {
                        array[i, kk] = 1;
                    }
                }
            }
            //PrintArray(array);

            for (int i = 0; i < 8; i++)
            {
                int number = int.Parse(Console.ReadLine());
                for (int kk = 0; kk < 8; kk++)
                {
                    if (((number >> kk) & 1) == 1)
                    {
                        if (array[i, kk] == 1)
                        {
                            array[i, kk] = 0;
                        }
                        else
                        {
                            array[i, kk] = 2;
                        }
                    }
                }
            }
            //PrintArray(array);

            int firstTeamGoals = 0;
            int secondTeamGoals = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (array[row, col] == 1)
                    {
                        if (row == 7)
                        {
                            firstTeamGoals++;
                        }
                        int newRow = row + 1;
                        while (newRow < 8 && array[newRow,col] == 0)
                        {
                            if (newRow == 7)
                            {
                                firstTeamGoals++;
                            }
                            newRow++;
                        }
                    }
                    if (array[row, col] == 2)
                    {
                        if (row == 0)
                        {
                            secondTeamGoals++;
                        }
                        int newRow = row - 1;
                        while (newRow > -1 && array[newRow, col] == 0)
                        {
                            if (newRow == 0)
                            {
                                secondTeamGoals++;
                            }
                            newRow--;
                        }
                    }
                }
            }
            Console.WriteLine("{0}:{1}", firstTeamGoals, secondTeamGoals);
            //PrintArray(array);
        }

        private static void PrintArray(int[,] array)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Console.Write(array[i, k]);
                }
                Console.WriteLine();
            }
        }
    }
}
