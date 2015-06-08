namespace _02.ArticlesByPriceRange
{
    using System;
    using System.Linq;

    using Wintellect.PowerCollections;

    /// <summary>
    /// A large trade company has millions of articles, each described by barcode, vendor, title and price. 
    /// Implement a data structure to store them that allows fast retrieval of all articles in given price 
    /// range [x…y]. Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int MaxValue = 1000000;

            var articles = new OrderedMultiDictionary<double, Article>(true);
            var randomNumberGenerator = new Random();
            double randomNumber;

            for (int i = 0; i < 200000; i++)
            {
                randomNumber = randomNumberGenerator.NextDouble() * MaxValue;
                var article = new Article("barcode" + i, "vendor" + i, "article" + i, randomNumber);

                articles.Add(article.Price, article);
            }

            Console.Write("from = ");
            double from = double.Parse(Console.ReadLine());
            Console.Write("to = ");
            double to = double.Parse(Console.ReadLine());
            var articlesInRange = articles.Range(from, true, to, true);

            foreach (var pair in articlesInRange)
            {
                foreach (var article in pair.Value)
                {
                    Console.WriteLine("{0} => {1}", Math.Round(article.Price, 2), article);
                }
            }
        }
    }
}
