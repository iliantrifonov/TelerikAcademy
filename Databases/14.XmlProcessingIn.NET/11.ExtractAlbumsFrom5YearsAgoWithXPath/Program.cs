namespace _11.ExtractAlbumsFrom5YearsAgoWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;

    /// <summary>
    /// Write a program, which extract from the file catalog.xml the prices for
    /// all albums, published 5 years ago or earlier. Use XPath query.
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
            var catalogues = new XmlDocument();
            catalogues.Load(pathToCatalogues);
            int currentYear = DateTime.Now.Year;
            int neededYear = currentYear - yearsAgo;

            string xPathQuery = "/catalogue/album";

            XmlNodeList albums = catalogues.SelectNodes(xPathQuery);

            var prices = new List<decimal>();

            foreach (XmlElement album in albums)
            {
                if (int.Parse(album.GetAttribute("year")) >= neededYear)
                {
                    var price = decimal.Parse(album.GetAttribute("price"));
                    prices.Add(price);
                }
            }

            return prices;
        }
    }
}
