namespace _02.ArticlesByPriceRange
{
    using System;
    public class Article : IComparable
    {
        private string barcode;
        private string vendor;
        private string title;
        private double price;

        public Article(string barcode, string vendor, string title, double price)
        {
            this.barcode = barcode;
            this.vendor = vendor;
            this.title = title;
            this.price = price;
        }

        public string Barcode
        {
            get
            {
                return this.barcode;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                this.barcode = value;
            }
        }

        public string Vendor
        {
            get
            {
                return this.vendor;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                this.vendor = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                this.title = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.price = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Article otherArticle = obj as Article;

            if (otherArticle != null)
            {
                return this.Price.CompareTo(otherArticle.Price);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} article - {1} is brought by {2} for {3}", this.title, this.barcode, this.vendor, Math.Round(this.price, 2)); 
        }
    }
}
