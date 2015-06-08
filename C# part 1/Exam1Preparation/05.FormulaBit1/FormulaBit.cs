
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FormulaBit1
{
    class FormulaBit
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 8];
            bool foundEnd = false;
            bool cannotStart = false;
            for (int row = 0; row < 8; row++)
            {
                byte num = byte.Parse(Console.ReadLine());
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = (num >> 7 - col) & 1;
                }
            }

            int column = 7;
            int rowReal = 0;
            string direction = "down";
            int count = 1;
            bool crashed = false;
            bool goneUp = false;
            int turns = 0;
            if (matrix[rowReal, column] == 1)
            {
                cannotStart = true;
            }
            while (true)
            {
                if (rowReal == 7 && column == 0 && matrix[rowReal, column] == 0)
                {
                    foundEnd = true;
                    break;
                }
                
                if (direction == "down")
                {
                    while (rowReal + 1 <= 7 && matrix[rowReal + 1, column] == 0)
                    {
                        count++;
                        rowReal++;
                        //matrix[rowReal, column] = 3;
                        if (rowReal == 7 && column == 0 && matrix[rowReal, column] == 0)
                        {
                            foundEnd = true;
                            break;
                        }
                    }
                    if (column - 1 < 0 || matrix[rowReal,column - 1] == 1 )
                    {
                        crashed = true;
                        break;
                    }
                    else
                    {
                        count++;
                        column--;
                        direction = "left";
                        turns++;
                        goneUp = false;
                        //matrix[rowReal, column] = 3;
                        if (rowReal == 7 && column == 0 && matrix[rowReal, column] == 0)
                        {
                            foundEnd = true;
                            break;
                        }
                    }
                }
                else if (direction == "left" )
                {
                    while (column - 1 >= 0 && matrix[rowReal, column - 1] == 0)
                    {
                        count++;
                        column--;
                        //matrix[rowReal, column] = 3;
                        if (rowReal == 7 && column == 0 && matrix[rowReal, column] == 0)
                        {
                            foundEnd = true;
                            break;
                        }
                    }
                    if (goneUp == false)
                    {
                        if (rowReal - 1 < 0 || matrix[rowReal - 1,column] == 1 )
                        {
                            crashed = true;
                            break;
                        }
                        else
                        {
                            count++;
                            rowReal--;
                            direction = "up";
                            goneUp = true;
                            turns++;
                            //matrix[rowReal, column] = 3;
                            if (rowReal == 7 && column == 0 && matrix[rowReal, column] == 0)
                            {
                                foundEnd = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (rowReal + 1 > 7 || matrix[rowReal + 1, column] == 1)
                        {
                            crashed = true;
                            break;
                        }
                        else
                        {
                            count++;
                            rowReal++;
                            direction = "down";
                            turns++;
                            //matrix[rowReal, column] = 3;
                            if (rowReal == 7 && column == 0 && matrix[rowReal, column] == 0)
                            {
                                foundEnd = true;
                                break;
                            }
                        }
                    }
                }
                else if (direction == "up")
                {
                    while (rowReal - 1 >= 0 && matrix[rowReal - 1, column] == 0)
                    {
                        count++;
                        rowReal--;
                        //matrix[rowReal, column] = 3;
                        if (rowReal == 7 && column == 0 && matrix[rowReal, column] == 0)
                        {
                            foundEnd = true;
                            break;
                        }
                    }
                    if (column - 1 < 0 || matrix[rowReal,column - 1] == 1 )
                    {
                        crashed = true;
                        break;
                    }
                    else
                    {
                        count++;
                        column--;
                        direction = "left";
                        turns++;
                        //matrix[rowReal, column] = 3;
                        if (rowReal == 7 && column == 0 && matrix[rowReal, column] == 0)
                        {
                            foundEnd = true;
                            break;
                        }
                    }
                }
                
            }
            if (cannotStart)
            {
                Console.WriteLine("No 0");
            }
            else if (foundEnd)
            {
                Console.WriteLine("{0} {1}", count, turns);
                
            }
            else if (crashed)
            {
                Console.WriteLine("No {0}", count);
            }
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(matrix[i,j]);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
