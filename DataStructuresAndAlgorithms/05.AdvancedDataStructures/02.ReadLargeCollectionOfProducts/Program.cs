namespace _02.ReadLargeCollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Wintellect.PowerCollections;

    /// <summary>
    /// Write a program to read a large collection of products (name + price) and 
    /// efficiently find the first 20 products in the price range [a…b]. Test for 
    /// 500 000 products and 10 000 price searches.
    /// Hint: you may use OrderedBag<T> and sub-ranges.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            int priceCheck = 200;
            var arrayOfProducts = GetRandomProducts();

            var sw = new Stopwatch();
            var bag = new OrderedBag<Product>();
            sw.Start();

            foreach (var item in arrayOfProducts)
            {
                bag.Add(item);
            }

            var lowerProduct = new Product("low", 150000);
            var higherProduct = new Product("high", 350000);

            for (int i = 0; i < priceCheck; i++)
            {
                bag.Range(lowerProduct, true, higherProduct, true);
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        private static void Solve(IEnumerable<Product> arrayOfProducts)
        {
           
        }

        private static Product[] GetRandomProducts()
        {
            var random = new Random();
            int count = 500000;
            var productsToReturn = new Product[count];
            for (int i = 0; i < count; i++)
            {
                productsToReturn[i] = new Product(new string((char)random.Next(65, 91), random.Next(3, 7)), random.Next(1, count));
            }

            return productsToReturn;
        }
    }
}
