namespace _01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program based on dynamic programming to solve the 
    /// "Knapsack Problem": you are given N products, each has weight
    /// Wi and costs Ci and a knapsack of capacity M and you want to 
    /// put inside a subset of the products with highest cost and weight
    /// ≤ M. The numbers N, M, Wi and Ci are integers in the range [1..500]. 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var items = new List<KnapsackElement>();

            items.Add(new KnapsackElement("beer", 3, 2));
            items.Add(new KnapsackElement("vodka", 8, 12));
            items.Add(new KnapsackElement("cheese", 4, 5));
            items.Add(new KnapsackElement("nuts", 1, 4));
            items.Add(new KnapsackElement("ham", 2, 3));
            items.Add(new KnapsackElement("whiskey", 8, 13));
            var maxCostElements = GetMaxCostElements(items, 10);

            foreach (var element in maxCostElements)
            {
                Console.WriteLine(element);
            }
        }

        public static IList<KnapsackElement> GetMaxCostElements(IList<KnapsackElement> elements, int knapsackWeight)
        {
            int[,] price = new int[elements.Count + 1, knapsackWeight + 1];
            bool[,] used = new bool[elements.Count + 1, knapsackWeight + 1];
            for (int elementIndex = 1; elementIndex < price.GetLength(0); elementIndex++)
            {
                var currentElement = elements[elementIndex - 1];
                for (int weights = 1; weights < price.GetLength(1); weights++)
                {
                    int currentMaxPrice = price[elementIndex - 1, weights];
                    if (currentElement.Weight <= weights)
                    {
                        int leftOverWeight = weights - currentElement.Weight;

                        if (currentElement.Price > currentMaxPrice)
                        {
                            currentMaxPrice = currentElement.Price;
                            used[elementIndex, weights] = true;
                        }

                        if (leftOverWeight > 0)
                        {
                            if (price[elementIndex - 1, leftOverWeight] + currentElement.Price > currentMaxPrice)
                            {
                                currentMaxPrice = price[elementIndex - 1, leftOverWeight] + currentElement.Price;
                                used[elementIndex, weights] = true;
                            }
                        }
                    }

                    price[elementIndex, weights] = currentMaxPrice;
                }
            }

            var resultElements = new List<KnapsackElement>();

            int row = price.GetLength(0) - 1;
            int col = price.GetLength(1) - 1;
            while (row >= 1)
            {
                if (used[row, col] == true)
                {
                    resultElements.Add(elements[row - 1]);
                    col = col - elements[row - 1].Weight;
                }

                row--;
            }

            return resultElements;
        }
    }
}
