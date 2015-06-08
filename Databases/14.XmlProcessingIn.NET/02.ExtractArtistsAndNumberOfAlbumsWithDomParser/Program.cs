namespace _02.ExtractArtistsAndNumberOfAlbumsWithDomParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Write program that extracts all different artists which are found 
    /// in the catalog.xml. For each author you should print the number of albums 
    /// in the catalogue. Use the DOM parser and a hash-table.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var document = new XmlDocument();
            document.Load("../../../01.CreateXmlRepresentingCatalogue/catalogue.xml");
            var catalogue = document.DocumentElement;
            var albums = catalogue.ChildNodes;

            var numberOfAlbumsByArtist = new Dictionary<string, int>();
            foreach (XmlNode album in albums)
            {
                var albumAttributes = album.Attributes;
                string artistName = null;
                foreach (XmlAttribute attr in albumAttributes)
                {
                    if (attr.Name == "artist")
                    {
                        artistName = attr.Value;
                        break;
                    }
                }

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
