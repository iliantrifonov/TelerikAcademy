using System;

namespace KukataIsDancing
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(KukataDance(Console.ReadLine()));
            }
        }

        public static string KukataDance(string a)
        {
            //red = 0
            //blue = 1
            //green = 2
            Dancer.directionRow = 1;
            Dancer.directionCol = 0;
            int[,] arr = new int[3, 3];
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (row == 1 && col == 1)
                    {
                        arr[row, col] = 2;
                    }
                    else if ((row == 0 && (col == 0 || col == 2)) || (row == 2 && (col == 0 || col == 2)))
                    {
                        arr[row, col] = 0;
                    }
                    else
                    {
                        arr[row, col] = 1;
                    }
                }
            }
            int rows = 1;
            int cols = 1;
            for (int i = 0; i < a.Length; i++)
            {
                if (rows > 2)
                {
                    rows = 0;
                }
                else if (rows < 0)
                {
                    rows = 2;
                }
                if (cols > 2)
                {
                    cols = 0;
                }
                else if (cols < 0)
                {
                    cols = 2;
                }
                if (a[i] == 'W')
                {
                    rows += Dancer.directionRow;
                    cols += Dancer.directionCol;
                }
                else
                {
                    Dancer.ChangeDirection(a[i]);
                }
            }
            if (rows > 2)
            {
                rows = 2;
                Dancer.directionRow = -1;
            }
            else if (rows < 0)
            {
                rows = 0;
                Dancer.directionRow = 1;
            }
            if (cols > 2)
            {
                cols = 2;
                Dancer.directionCol = -1;
            }
            else if (cols < 0)
            {
                cols = 0;
                Dancer.directionCol = 1;
            }
            if (arr[rows, cols] == 0)
            {
                return "RED";
            }
            else if (arr[rows, cols] == 1)
            {
                return "BLUE";
            }
            else
            {
                return "GREEN";
            }
        }
    }

    public class Dancer
    {
        public static int directionRow = 1;
        public static int directionCol = 0;

        public Dancer()
        {
            directionRow = 1;
            directionCol = 0;
        }

        public static void ChangeDirection(char a)
        {
            if (a == 'L')
            {
                if (Dancer.directionCol == 0)
                {
                    if (Dancer.directionRow == 1)
                    {
                        Dancer.directionCol = 1;
                    }
                    else
                    {
                        Dancer.directionCol = -1;
                    }
                    Dancer.directionRow = 0;
                }
                else
                {
                    if (Dancer.directionCol == 1)
                    {
                        Dancer.directionRow = -1;
                    }
                    else
                    {
                        Dancer.directionRow = 1;
                    }
                    Dancer.directionCol = 0;
                }
            }
            else
            {
                if (Dancer.directionCol == 0)
                {
                    if (Dancer.directionRow == 1)
                    {
                        Dancer.directionCol = -1;
                    }
                    else
                    {
                        Dancer.directionCol = 1;
                    }
                    Dancer.directionRow = 0;
                }
                else
                {
                    if (Dancer.directionCol == 1)
                    {
                        Dancer.directionRow = 1;
                    }
                    else
                    {
                        Dancer.directionRow = -1;
                    }
                    Dancer.directionCol = 0;
                }
            }
        }
    }
}
