namespace _05.ExtractAllSongsWithXmlReader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Write a program, which using XmlReader extracts all song titles from catalog.xml
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var reader = XmlReader.Create("../../../01.CreateXmlRepresentingCatalogue/catalogue.xml");
            var titles = new List<string>();
            using (reader)
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        titles.Add(reader.ReadInnerXml());
                    }
                }
            }

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
