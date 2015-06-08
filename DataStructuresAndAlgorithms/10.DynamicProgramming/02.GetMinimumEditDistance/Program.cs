namespace _02.GetMinimumEditDistance
{
    using System;
    using System.Linq;

    /// <summary>
    /// Write a program to calculate the "Minimum Edit Distance" (MED) between two words. MED(x, y) is the minimal sum of costs of edit operations used to transform x to y. Sample costs are given below:
    /// cost (replace a letter) = 1
    /// cost (delete a letter) = 0.9
    /// cost (insert a letter) = 0.8

    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MinimumEditDistance("developer", "enveloped"));
        }

        public static decimal MinimumEditDistance(string firstWord, string secondWord)
        {
            decimal[,] cost = new decimal[firstWord.Length + 1, secondWord.Length + 1];
            decimal deleteCost = 0.9m;
            decimal insertCost = 0.8m;
            decimal replaceCost = 1;
            for (int i = 1; i < cost.GetLength(0); i++)
            {
                cost[i, 0] = cost[i - 1, 0] + deleteCost;
            }

            for (int i = 1; i < cost.GetLength(1); i++)
            {
                cost[0, i] = cost[0, i - 1] + insertCost;
            }

            for (int firstWordIndex = 1; firstWordIndex < cost.GetLength(0); firstWordIndex++)
            {
                for (int secondWordIndex = 1; secondWordIndex < cost.GetLength(1); secondWordIndex++)
                {
                    decimal replace = cost[firstWordIndex - 1, secondWordIndex - 1];
                    if (firstWord[firstWordIndex - 1] != secondWord[secondWordIndex - 1])
                    {
                        replace += replaceCost;
                    }

                    decimal delete = cost[firstWordIndex - 1, secondWordIndex] + deleteCost;
                    decimal insert = cost[firstWordIndex, secondWordIndex - 1] + insertCost;

                    cost[firstWordIndex, secondWordIndex] = Math.Min(Math.Min(replace, delete), insert);
                }
            }

            for (int i = 0; i < cost.GetLength(0); i++)
            {
                for (int k = 0; k < cost.GetLength(1); k++)
                {
                    Console.Write(string.Format("{0, -5}", cost[i, k]));
                }

                Console.WriteLine();
            }

            return cost[cost.GetLength(0) - 1, cost.GetLength(1) - 1];
        }
    }
}
