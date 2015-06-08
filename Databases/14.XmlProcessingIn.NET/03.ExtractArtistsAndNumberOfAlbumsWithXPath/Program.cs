namespace _03.ExtractArtistsAndNumberOfAlbumsWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Write program that extracts all different artists which are 
    /// found in the catalog.xml. For each author you should print 
    /// the number of albums in the catalogue. Use XPath
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var catalogue = XDocument.Load("../../../01.CreateXmlRepresentingCatalogue/catalogue.xml");

            var albums = catalogue.Descendants("album");

            var artists = albums.Select(a => (string)a.Attribute("artist"));

            var numberOfAlbumsByArtist = new Dictionary<string, int>();
            foreach (var artistName in artists)
            {
                if (numberOfAlbumsByArtist.ContainsKey(artistName))
                {
                    numberOfAlbumsByArtist[artistName] += 1;
                }
                else
                {
                    numberOfAlbumsByArtist.Add(artistName, 1);
                }
            }

            foreach (var pair in numberOfAlbumsByArtist)
            {
                Console.WriteLine("Artist: {0} has {1} songs", pair.Key, pair.Value);
            }
        }
    }
}
