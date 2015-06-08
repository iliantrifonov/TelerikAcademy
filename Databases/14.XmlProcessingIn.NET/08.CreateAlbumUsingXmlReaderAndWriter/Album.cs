namespace _08.CreateAlbumUsingXmlReaderAndWriter
{
    public class Album
    {
        public Album(string name, string author)
        {
            this.Name = name;
            this.Author = author;
        }

        public string Name { get; set; }

        public string Author { get; set; }
    }
}
