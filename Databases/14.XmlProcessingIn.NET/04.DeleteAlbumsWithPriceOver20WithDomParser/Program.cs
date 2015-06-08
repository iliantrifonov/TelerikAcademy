namespace _04.DeleteAlbumsWithPriceOver20WithDomParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    /// <summary>
    /// Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            DeleteElementsWithPriceOver(20, "../../../01.CreateXmlRepresentingCatalogue/catalogue.xml");
        }

        private static void DeleteElementsWithPriceOver(decimal price, string filePath)
        {
            var document = new XmlDocument();
            document.Load(filePath);
            var catalogue = document.DocumentElement;
            var albums = catalogue.ChildNodes;
            var albumsToRemove = new List<XmlNode>();

            foreach (XmlNode album in albums)
            {
                foreach (XmlAttribute attr in album.Attributes)
                {
                    if (attr.Name == "price")
                    {
                        var currentAlbumPrice = decimal.Parse(attr.Value);
                        if (price < currentAlbumPrice)
                        {
                            albumsToRemove.Add(album);
                        }

                        break;
                    }
                }
            }

            foreach (var album in albumsToRemove)
            {
                catalogue.RemoveChild(album);
            }

            document.Save(filePath);
        }
    }
}
