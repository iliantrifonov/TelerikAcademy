namespace _06.ExtractAllSongsWithXDocument
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Write a program, which using XDocument and LINQ query extracts all song titles from catalog.xml.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var catalogue = XElement.Load("../../../01.CreateXmlRepresentingCatalogue/catalogue.xml");

            var albums = catalogue.Descendants("song");
            var titles = albums.Select(a => a.Element("title").Value);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
