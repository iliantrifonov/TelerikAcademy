namespace CatalogOfFreeContent
{
    using System;

    public class Content : IComparable<IContent>, IContent
    {
        private string url;
        private string title;
        private string author;
        private long size;
        private ContentType type;

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)InnerType.Title];
            this.Author = commandParams[(int)InnerType.Author];
            this.Size = long.Parse(commandParams[(int)InnerType.Size]);
            this.Url = commandParams[(int)InnerType.Url];
        }

        public string Title 
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                this.author = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public ContentType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public string TextRepresentation { get; set; }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);

            return output;
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                throw new ArgumentException("Cannot compare to Null.");
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResult;
            }

            throw new ArgumentException("Object is not of type Content");
        }

        public int CompareTo(IContent obj)
        {
            if (null == obj)
            {
                throw new ArgumentException("Cannot compare to Null.");
            }

            IContent otherContent = obj;
            int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

            return comparisonResult;
        }
    }
}