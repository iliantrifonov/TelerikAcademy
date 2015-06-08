namespace _01.CreateXmlRepresentingCatalogue
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Create a XML file representing catalogue. The catalogue should 
    /// contain albums of different artists. For each album you should define:
    /// name, artist, year, producer, price and a list of songs. Each song 
    /// should be described by title and duration.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var catalogue = new XElement("catalogue");

            for (int i = 0; i < 5; i++)
            {
                var currentAlbum = new XElement("album");
                currentAlbum.Add(new XAttribute("artist", "Artist name"));
                currentAlbum.Add(new XAttribute("album-name", "Album " + i));
                currentAlbum.Add(new XAttribute("year", 2007 + i));
                currentAlbum.Add(new XAttribute("producer", "Some record company " + i));
                currentAlbum.Add(new XAttribute("price", 18.3 + i));

                for (int k = 0; k < 10; k++)
                {
                    var currentSong = new XElement("song");
                    var title = new XElement("title");
                    title.Value = k +" Song name " + i;
                    currentSong.Add(title);

                    var duration = new XElement("duration");
                    duration.Value = (0.33 + k + i).ToString();
                    currentSong.Add(duration);

                    currentAlbum.Add(currentSong);
                }

                catalogue.Add(currentAlbum);
            }

            catalogue.Save("../../catalogue.xml");
        }
    }
}
