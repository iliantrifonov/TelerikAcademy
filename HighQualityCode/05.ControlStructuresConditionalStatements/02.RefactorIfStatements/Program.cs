namespace _02.RefactorIfStatements
{
    using System;
    using System.Linq;
    using _01.OrganizeStraightLineCode;

    public class Program
    {
        private const int MAX_X = int.MaxValue;
        private const int MIN_X = int.MinValue;
        private const int MAX_Y = int.MaxValue;
        private const int MIN_Y = int.MinValue;

        public static void Main(string[] args)
        {
        }

        public static void CellChecker()
        {
            int x = 5;
            int y = 6;

            if (IsVisited(x, y))
            {
                // some logic here
            }
            else if (InBounds(x, y))
            {
                VisitCell();
            }
        }

        public static void CookPotato()
        {
            Potato potato = new Potato();

            // ...
            if (potato == null || potato.IsRotten)
            {
                throw new ArgumentException("Invalid potato");
            }
            else if (potato.IsPeeled)
            {
                var chef = new Chef();
                chef.Cook(potato);
            }
        }

        private static bool IsVisited(int x, int y)
        {
            // does some smarter logic than just returning a value
            return false;
        }

        private static bool InBounds(int x, int y)
        {
            if (x >= MIN_X && x <= MAX_X)
            {
                if (y >= MIN_Y && y <= MAX_Y)
                {
                    return true;
                }
            }

            return false;
        }

        private static void VisitCell()
        {
            // ... Also marks cell as visited..
        }
    }
}
