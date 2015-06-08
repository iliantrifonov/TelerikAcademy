namespace _12.ExtractAlbumsFrom5YearsAgoWithLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Write a program, which extract from the file catalog.xml the prices for all albums, 
    /// published 5 years ago or earlier. Use Linq query.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string pathToCatalogues = "../../../01.CreateXmlRepresentingCatalogue/catalogue.xml";
            int yearsAgo = 5;
            var prices = ExtractPricesForAlbumsFrom(yearsAgo, pathToCatalogues);

            foreach (var price in prices)
            {
                Console.WriteLine(price);
            }
        }

        private static IEnumerable<decimal> ExtractPricesForAlbumsFrom(int yearsAgo, string pathToCatalogues)
        {
            var catalogues = XElement.Load(pathToCatalogues);

            var albums = catalogues.Descendants("album");

            int currentYear = DateTime.Now.Year;
            int neededYear = currentYear - yearsAgo;

            var prices = albums.Where(a => (int)a.Attribute("year") >= neededYear).Select(al => (decimal)al.Attribute("price"));

            return prices;
        }
    }
}
