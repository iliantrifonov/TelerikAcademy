namespace _14.FillLabirinthWithMinimalDistance
{
    using System;

    /// <summary>
    /// * We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x). We can move from an empty cell to another empty cell if they share common wall. Given a starting position (*) calculate and fill in the array the minimal distance from this position to any other cell in the array. Use "u" for all unreachable cells. 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] inputField = new string[6,6] 
            {
               { "0", "0", "0", "x", "0", "x", },
               { "0", "x", "0", "x", "0", "x", },
               { "0", "*", "x", "0", "x", "0", },
               { "0", "x", "0", "0", "0", "0", },
               { "0", "0", "0", "x", "x", "0", },
               { "0", "0", "0", "x", "0", "x", },
            };

            Labyrinth labyrinth = new Labyrinth(inputField);
            labyrinth.FillDistance();

            Console.WriteLine(labyrinth.ToString());
        }
    }
}
