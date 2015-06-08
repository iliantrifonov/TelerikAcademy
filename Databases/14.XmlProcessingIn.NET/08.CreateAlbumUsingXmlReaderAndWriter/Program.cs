namespace _08.CreateAlbumUsingXmlReaderAndWriter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Write a program, which (using XmlReader and XmlWriter) reads the
    /// file catalog.xml and creates the file album.xml, in which stores 
    /// in appropriate way the names of all albums and their authors.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var reader = XmlReader.Create("../../../01.CreateXmlRepresentingCatalogue/catalogue.xml");
            var albums = new List<Album>();

            using (reader)
            {
                while (reader.Read())
                {
                    if (reader.Name == "album")
                    {
                        var albumName = reader.GetAttribute("album-name");
                        var artistName = reader.GetAttribute("artist");
                        if (albumName != null && artistName != null)
                        {
                            var album = new Album(albumName, artistName);
                            albums.Add(album);
                        }
                    }
                }
            }

            var writer = XmlWriter.Create("../../album.xml");

            using (writer)
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("albums");

                foreach (var album in albums)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", album.Name);
                    writer.WriteElementString("author", album.Author);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }
    }
}
