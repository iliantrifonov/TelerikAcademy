using System;
using System.Collections.Generic;

namespace Game
{
    public class Mines
    {
        private static void Main(string[] аргументи)
        {
            string command = string.Empty;
            char[,] field = CreateField();
            char[,] bombs = InitializeBombs();
            int counter = 0;
            bool isFinished = false;
            List<Point> highscoreList = new List<Point>(6);
            int row = 0;
            int col = 0;
            bool isStarting = true;
            bool hasWon = false;
            const int Max = 35;

            do
            {
                if (isStarting)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawField(field);
                    isStarting = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col) && row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintHighscore(highscoreList);
                        break;

                    case "restart":
                        field = CreateField();
                        bombs = InitializeBombs();
                        DrawField(field);
                        isFinished = false;
                        isStarting = false;
                        break;

                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;

                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                Turn(field, bombs, row, col);
                                counter++;
                            }

                            if (Max == counter)
                            {
                                hasWon = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            isFinished = true;
                        }

                        break;

                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isFinished)
                {
                    DrawField(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", counter);
                    string name = Console.ReadLine();
                    Point point = new Point(name, counter);
                    if (highscoreList.Count < 5)
                    {
                        highscoreList.Add(point);
                    }
                    else
                    {
                        for (int i = 0; i < highscoreList.Count; i++)
                        {
                            if (highscoreList[i].Points < point.Points)
                            {
                                highscoreList.Insert(i, point);
                                highscoreList.RemoveAt(highscoreList.Count - 1);
                                break;
                            }
                        }
                    }

                    highscoreList.Sort((Point r1, Point r2) => r2.Name.CompareTo(r1.Name));
                    highscoreList.Sort((Point r1, Point r2) => r2.Points.CompareTo(r1.Points));
                    PrintHighscore(highscoreList);

                    field = CreateField();
                    bombs = InitializeBombs();
                    counter = 0;
                    isFinished = false;
                    isStarting = true;
                }

                if (hasWon)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawField(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    Point to4kii = new Point(imeee, counter);
                    highscoreList.Add(to4kii);
                    PrintHighscore(highscoreList);
                    field = CreateField();
                    bombs = InitializeBombs();
                    counter = 0;
                    hasWon = false;
                    isStarting = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintHighscore(List<Point> points)
        {
            Console.WriteLine("\nTo4KI:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void Turn(char[,] field, char[,] bombs, int row, int col)
        {
            char countBombs = CountBombs(bombs, row, col);
            bombs[row, col] = countBombs;
            field[row, col] = countBombs;
        }

        private static void DrawField(char[,] field)
        {
            int row = field.GetLength(0);
            int col = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] field = new char[fieldRows, fieldColumns];
            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    field[i, j] = '?';
                }
            }

            return field;
        }

        private static char[,] InitializeBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random random = new Random();
                int number = random.Next(50);
                if (!bombs.Contains(number))
                {
                    bombs.Add(number);
                }
            }

            foreach (int bomb in bombs)
            {
                int col = bomb / cols;
                int row = bomb % cols;
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = '*';
            }

            return field;
        }

        private static void Calculate(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char amountOfBombs = CountBombs(field, i, j);
                        field[i, j] = amountOfBombs;
                    }
                }
            }
        }

        private static char CountBombs(char[,] field, int row, int col)
        {
            int countBombs = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    countBombs++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    countBombs++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    countBombs++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    countBombs++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    countBombs++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    countBombs++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    countBombs++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    countBombs++;
                }
            }

            return char.Parse(countBombs.ToString());
        }
    }
}