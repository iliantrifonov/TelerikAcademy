namespace _07.FindAllPathsInLabirynth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// We are given a matrix of passable and non-passable cells. Write a recursive 
    /// program for finding all paths between two cells in the matrix.
    /// </summary>
    public class Program
    {
        private static char[,] labyrinth = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        };

        public static void Main(string[] args)
        {
            var startPosition = new Tuple<int, int>(0, 0);
            var endPosition = new Tuple<int, int>(4, 6);
            var path = new List<Tuple<int, int>>();
            FindAllPaths(startPosition, endPosition, path);
        }

        private static void FindAllPaths(Tuple<int, int> currentPosition, Tuple<int, int> endPosition, List<Tuple<int, int>> path)
        {
            if (IsInRange(currentPosition))
            {
                if (labyrinth[currentPosition.Item1, currentPosition.Item2] != ' ')
                {
                    return;
                }

                if (currentPosition.Item1 == endPosition.Item1 && currentPosition.Item2 == endPosition.Item2)
                {
                    path.Add(currentPosition);
                    PrintPath(path);
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

        private static bool IsInRange(Tuple<int, int> currentPosition)
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

        private static void PrintPath(List<Tuple<int, int>> path)
        {
            var sb = new StringBuilder();
            foreach (var position in path)
            {
                sb.Append("(");
                sb.Append(position.Item1);
                sb.Append(", ");
                sb.Append(position.Item2);
                sb.Append("), ");
            }

            sb.Remove(sb.Length - 2, 2);
            Console.WriteLine(sb.ToString());
        }
    }
}
