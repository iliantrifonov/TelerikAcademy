using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Digits
{
    class Program
    {
        static int[,] matrix;
        static int result = 0;

        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            matrix = new int[size, size];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Queue<string> input = GetInput(Console.ReadLine());
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = int.Parse(input.Dequeue());
                }
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    switch (matrix[row, col])
                    {
                        case 1:
                            FoundOne(row, col);
                            break;
                        case 2:
                            FoundTwo(row, col);
                            break;
                        case 3:
                            FoundThree(row, col);
                            break;
                        case 4:
                            FoundFour(row, col);
                            break;
                        case 5:
                            FoundFive(row, col);
                            break;
                        case 6:
                            FoundSix(row, col);
                            break;
                        case 7:
                            FoundSeven(row, col);
                            break;
                        case 8:
                            FoundEight(row, col);
                            break;
                        case 9:
                            FoundNine(row, col);
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(result);
        }

        private static void FoundNine(int row, int col)
        {
            try
            {
                row--;
                col--;
                if (matrix[row, col] != 9)
                {
                    return;
                }
                row--;
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 9)
                    {
                        return;
                    }
                    col++;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (matrix[row, col] != 9)
                    {
                        return;
                    }
                    row++;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (matrix[row, col] != 9)
                    {
                        return;
                    }
                    col--;
                }
                result += 9;
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void FoundEight(int row, int col)
        {
            try
            {
                row--;
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 8)
                    {
                        return;
                    }
                    col++;
                }
                if (matrix[row, col] != 8)
                {
                    return;
                }
                row++;
                if (matrix[row, col] != 8)
                {
                    return;
                }
                row++;
                col--;
                if (matrix[row, col] != 8)
                {
                    return;
                }
                row++;
                col--;
                if (matrix[row, col] != 8)
                {
                    return;
                }
                row++;

                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 8)
                    {
                        return;
                    }
                    col++;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 8)
                    {
                        return;
                    }
                    row--;
                }
                result += 8;
            }
            catch (Exception)
            {
                return;
            }

        }

        private static void FoundSix(int row, int col)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 6)
                    {
                        return;
                    }
                    col--;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (matrix[row, col] != 6)
                    {
                        return;
                    }
                    row++;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 6)
                    {
                        return;
                    }
                    col++;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 6)
                    {
                        return;
                    }
                    row--;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 6)
                    {
                        return;
                    }
                    col--;
                }
                result += 6;
            }
            catch (Exception)
            {
                return;
            }

        }

        private static void FoundFive(int row, int col)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 5)
                    {
                        return;
                    }
                    col--;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 5)
                    {
                        return;
                    }
                    row++;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 5)
                    {
                        return;
                    }
                    col++;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 5)
                    {
                        return;
                    }
                    row++;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (matrix[row, col] != 5)
                    {
                        return;
                    }
                    col--;
                }
                result += 5;
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void FoundFour(int row, int col)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 4)
                    {
                        return;
                    }
                    row++;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 4)
                    {
                        return;
                    }
                    col++;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 4)
                    {
                        return;
                    }
                    row--;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (matrix[row, col] != 4)
                    {
                        return;
                    }
                    row++;
                }
                result += 4;
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void FoundThree(int row, int col)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 3)
                    {
                        return;
                    }
                    col++;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (matrix[row, col] != 3)
                    {
                        return;
                    }
                    row++;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (matrix[row, col] != 3)
                    {
                        return;
                    }
                    col--;
                }
                if (matrix[row - 2, col + 2] != 3)
                {
                    return;
                }
                result += 3;
            }
            catch (Exception)
            {

            }

        }

        private static void FoundTwo(int row, int col)
        {
            try
            {
                row--;
                col++;
                if (matrix[row, col] != 2)
                {
                    return;
                }
                row++;
                col++;
                if (matrix[row, col] != 2)
                {
                    return;
                }
                row++;
                if (matrix[row, col] != 2)
                {
                    return;
                }
                row++;
                col--;
                if (matrix[row, col] != 2)
                {
                    return;
                }
                row++;
                col--;
                if (matrix[row, col] != 2)
                {
                    return;
                }
                col++;
                if (matrix[row, col] != 2)
                {
                    return;
                }
                col++;
                if (matrix[row, col] != 2)
                {
                    return;
                }
                result += 2;
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void FoundSeven(int row, int col)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 7)
                    {
                        return;
                    }
                    col++;
                }
                for (int i = 0; i < 1; i++)
                {
                    if (matrix[row, col] != 7)
                    {
                        return;
                    }
                    row++;
                }
                if (matrix[row, col] != 7)
                {
                    return;
                }
                row++;
                col--;
                for (int i = 0; i < 3; i++)
                {
                    if (matrix[row, col] != 7)
                    {
                        return;
                    }
                    row++;
                }
                result += 7;
            }
            catch (Exception)
            {
                return;
            }
        }

        private static void FoundOne(int row, int col)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    if (matrix[row, col] != 1)
                    {
                        return;
                    }
                    row--;
                    col++;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (matrix[row, col] != 1)
                    {
                        return;
                    }
                    row++;
                }
                result += 1;
            }
            catch (Exception)
            {
                return;
            }

        }

        private static Queue<string> GetInput(string a)
        {
            Queue<string> que = new Queue<string>();
            string[] nums = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < nums.Length; i++)
            {
                que.Enqueue(nums[i]);
            }
            return que;
        }
    }
}