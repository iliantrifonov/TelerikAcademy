namespace _12.Refactoring
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = GetN();

            var walkInMatrix = new WalkInMatrix(n);
            var matrix = walkInMatrix.GetMatrix();
            var a = walkInMatrix.ToString();
            PrintMatrixOnConsole(matrix);
        }

        private static int GetN()
        {
            int n = 0;
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }

        private static void PrintMatrixOnConsole(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write("{0,3}", matrix[rows, cols]);
                }

                Console.WriteLine();
            }
        }
    }
}