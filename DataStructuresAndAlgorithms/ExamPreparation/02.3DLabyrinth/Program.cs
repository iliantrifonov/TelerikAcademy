namespace _02._3DLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/430
    /// </summary>
    public class Program
    {
        private static HashSet<Cell> usedNodes = new HashSet<Cell>();
        public static void Main(string[] args)
        {
            var startPosition = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var labSizes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int levels = labSizes[0];
            int rows = labSizes[1];
            int cols = labSizes[2];
            char[, ,] lab = new char[rows, cols, levels];

            for (int l = 0; l < levels; l++)
            {
                for (int r = 0; r < rows; r++)
                {
                    var cell = Console.ReadLine().Trim().ToCharArray();
                    for (int c = 0; c < cols; c++)
                    {
                        lab[r, c, l] = cell[c];
                        if (cell[c] == '#')
                        {
                            usedNodes.Add(new Cell(l, r, c, -1));
                        }
                    }
                }
            }

            var startCell = new Cell(startPosition[0], startPosition[1], startPosition[2], 0);

            BFS(lab, startCell);
        }

        private static void BFS(char[, ,] lab, Cell startCell)
        {
            var r = lab.GetLength(0);
            var c = lab.GetLength(1);
            var l = lab.GetLength(2);

            var queue = new Queue<Cell>();

            queue.Enqueue(startCell);

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                
                // go forward
                if (!usedNodes.Contains(new Cell(cur.PosL, cur.PosR + 1, cur.PosC, cur.Moves + 1)) && cur.PosR + 1 < r)
                {
                    usedNodes.Add(new Cell(cur.PosL, cur.PosR + 1, cur.PosC, cur.Moves + 1));
                    queue.Enqueue(new Cell(cur.PosL, cur.PosR + 1, cur.PosC, cur.Moves + 1));
                }

                // go back
                if (!usedNodes.Contains(new Cell(cur.PosL, cur.PosR - 1, cur.PosC, cur.Moves + 1)) && cur.PosR - 1 > -1)
                {
                    usedNodes.Add(new Cell(cur.PosL, cur.PosR - 1, cur.PosC, cur.Moves + 1));
                    queue.Enqueue(new Cell(cur.PosL, cur.PosR - 1, cur.PosC, cur.Moves + 1));
                }

                // go left
                if (!usedNodes.Contains(new Cell(cur.PosL, cur.PosR, cur.PosC - 1, cur.Moves + 1)) && cur.PosC - 1 > -1)
                {
                    usedNodes.Add(new Cell(cur.PosL, cur.PosR, cur.PosC - 1, cur.Moves + 1));
                    queue.Enqueue(new Cell(cur.PosL, cur.PosR, cur.PosC - 1, cur.Moves + 1));
                }

                // go right
                if (!usedNodes.Contains(new Cell(cur.PosL, cur.PosR, cur.PosC + 1, cur.Moves + 1)) && cur.PosC + 1 < c)
                {
                    usedNodes.Add(new Cell(cur.PosL, cur.PosR, cur.PosC + 1, cur.Moves + 1));
                    queue.Enqueue(new Cell(cur.PosL, cur.PosR, cur.PosC + 1, cur.Moves + 1));
                }

                // check U go up and check if exit
                if (lab[cur.PosR, cur.PosC, cur.PosL] == 'U')
                {
                    if (!usedNodes.Contains(new Cell(cur.PosL + 1, cur.PosR, cur.PosC, cur.Moves + 1)))
                    {
                        if (cur.PosL + 1 >= l)
                        {
                            Console.WriteLine(cur.Moves + 1);
                            return;
                        }

                        usedNodes.Add(new Cell(cur.PosL + 1, cur.PosR, cur.PosC, cur.Moves + 1));
                        queue.Enqueue(new Cell(cur.PosL + 1, cur.PosR, cur.PosC, cur.Moves + 1));
                    }
                }

                // check d go down and check if exit
                if (lab[cur.PosR, cur.PosC, cur.PosL] == 'D')
                {
                    if (!usedNodes.Contains(new Cell(cur.PosL - 1, cur.PosR, cur.PosC, cur.Moves + 1)))
                    {
                        if (cur.PosL - 1 < 0)
                        {
                            Console.WriteLine(cur.Moves + 1);
                            return;
                        }

                        usedNodes.Add(new Cell(cur.PosL - 1, cur.PosR, cur.PosC, cur.Moves + 1));
                        queue.Enqueue(new Cell(cur.PosL - 1, cur.PosR, cur.PosC, cur.Moves + 1));
                    }
                }
            }
        }
    }
}
