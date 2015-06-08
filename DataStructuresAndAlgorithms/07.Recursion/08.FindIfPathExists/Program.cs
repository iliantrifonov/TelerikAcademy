namespace _08.FindIfPathExists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Modify the above program to check whether a path exists between two cells without 
    /// finding all possible paths. Test it over an empty 100 x 100 matrix.
    /// </summary>
    public class Program
    {
        internal static bool existPath = false;
        
        public static char[,] labyrinth;

        public static void Main()
        {
            labyrinth = new char[,]
            {
                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                {'*', '*', ' ', '*', ' ', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', '*', '*', '*', '*', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            };

            // test with empty array [100, 100]
            //labyrinth = new char[100, 100];
            //for (int i = 0; i < 100; i++)
            //{
            //    for (int j = 0; j < 100; j++)
            //    {
            //        labyrinth[i, j] = ' ';
            //    }
            //}

            var startPosition = new Tuple<int, int>(0, 0);
            var endPosition = new Tuple<int, int>(4, 6);
            var path = new List<Tuple<int, int>>();
            FindAllPaths(startPosition, endPosition, path);

            Console.WriteLine(existPath);
        }

        public static bool IsInRange(Tuple<int, int> currentPosition)
        {
            if (currentPosition.Item1 < 0 || currentPosition.Item1 >= labyrinth.GetLength(0))
            {
                return false;
            }
            if (currentPosition.Item2 < 0 || currentPosition.Item2 >= labyrinth.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private static void FindAllPaths(Tuple<int, int> currentPosition, Tuple<int, int> endPosition, List<Tuple<int, int>> path)
        {
            if (IsInRange(currentPosition) && !existPath)
            {
                if (labyrinth[currentPosition.Item1, currentPosition.Item2] != ' ')
                {
                    return;
                }

                if (currentPosition.Item1 == endPosition.Item1 && currentPosition.Item2 == endPosition.Item2)
                {
                    path.Add(currentPosition);

                    existPath = true;

                    return;
                }

                labyrinth[currentPosition.Item1, currentPosition.Item2] = '*';
                path.Add(currentPosition);

                FindAllPaths(new Tuple<int, int>(currentPosition.Item1 + 1, currentPosition.Item2), endPosition, path);
                FindAllPaths(new Tuple<int, int>(currentPosition.Item1 - 1, currentPosition.Item2), endPosition, path);
                FindAllPaths(new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 + 1), endPosition, path);
                FindAllPaths(new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 - 1), endPosition, path);

                labyrinth[currentPosition.Item1, currentPosition.Item2] = ' ';

                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
