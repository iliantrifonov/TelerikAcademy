namespace Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Data;
    using Model;

    public class EntryPoint
    {
        private static DatabaseContext context;

        public static void Main(string[] args)
        {
            context = new DatabaseContext();

            // context = new DatabaseContext("SQLContextExpress");
            using (context)
            {
                context.Authors.All(x => true);
                var entryDataFilePath = "../../complex-books.xml";
                // Insert(entryDataFilePath);
                var queriesFilePath = "../../reviews-queries.xml";
                var outputFilePath = "../../reviews-search-results.xml";
                Search(queriesFilePath, outputFilePath);
            }
        }

        private static void Search(string queriesFilePath, string outputFilePath)
        {
            var queriesXmlFile = XElement.Load(queriesFilePath);
            var queriesXml = queriesXmlFile.Elements("query");

            var document = new XElement("search-results");
            foreach (var query in queriesXml)
            {
                IQueryable<Review> reviews = FindReviews(query);

                var reviewsNecessaryPart = reviews.Select(r => new
                {
                    DateOfCreation = r.DateOfCreation,
                    Content = r.Content,
                    Book = new
                    {
                        Title = r.Book.Title,
                        Authors = r.Book.Authors
                            .AsQueryable()
                            .Select(a => a.Name)
                            .AsQueryable(),
                        Isbn = r.Book.Isbn,
                        Url = r.Book.WebSite
                    }
                }
                );

                var resultSet = new XElement("result-set");

                foreach (var review in reviewsNecessaryPart)
                {
                    var reviewXml = new XElement("review");
                    var dateXml = new XElement("date");
                    dateXml.Value = review.DateOfCreation.ToString("d-MMM-yyyy");
                    reviewXml.Add(dateXml);

                    var contentXml = new XElement("content");
                    contentXml.Value = review.Content;
                    reviewXml.Add(contentXml);

                    var bookXml = new XElement("book");
                    var titleXml = new XElement("title", review.Book.Title);
                    bookXml.Add(titleXml);
                    if (review.Book.Authors.ToList().Count > 0)
                    {
                        string authorString = string.Join(", ", review.Book.Authors);
                        var authorsXml = new XElement("authors", authorString);
                        bookXml.Add(authorsXml);
                    }

                    if (review.Book.Isbn != null)
                    {
                        var isbnXml = new XElement("isbn", review.Book.Isbn);
                        bookXml.Add(isbnXml);
                    }

                    if (review.Book.Url != null)
                    {
                        var urlXml = new XElement("url", review.Book.Url);
                        bookXml.Add(urlXml);
                    }

                    reviewXml.Add(bookXml);

                    resultSet.Add(reviewXml);
                }

                document.Add(resultSet);
            }
            document.Save(outputFilePath);

        }

        private static IQueryable<Review> FindReviews(XElement query)
        {
            if (query.Attribute("type").Value == "by-author")
            {
                return FindReviewsByAuthor(query).AsQueryable();
            }
            else if (query.Attribute("type").Value == "by-period")
            {
                return FindReviewsByPeriod(query).AsQueryable();
            }

            throw new ArgumentException("The search type is invalid");
        }

        private static IQueryable<Review> FindReviewsByPeriod(XElement query)
        {
            var startDate = DateTime.Parse(query.Element("start-date").Value);
            var endDate = DateTime.Parse(query.Element("end-date").Value);

            return context.Reviews
                .Where(r => r.DateOfCreation >= startDate && r.DateOfCreation <= endDate)
                .OrderBy(re => re.DateOfCreation)
                .ThenBy(rev => rev.Content)
                .AsQueryable();
        }

        private static IQueryable<Review> FindReviewsByAuthor(XElement query)
        {
            var authorName = query.Element("author-name").Value;

            var reviews = context.Reviews
                .Where(r => r.Author.Name == authorName)
                .OrderBy(re => re.DateOfCreation)
                .ThenBy(rev => rev.Content)
                .AsQueryable();

            return reviews;
        }

        private static void Insert(string filePath)
        {
            var catalog = XElement.Load(filePath);

            var books = catalog.Elements("book");

            foreach (var xmlBook in books)
            {
                var currentBook = new Book();

                var price = xmlBook.Element("price");
                if (price != null)
                {
                    currentBook.Price = decimal.Parse(price.Value);
                }

                var isbn = xmlBook.Element("isbn");
                if (isbn != null)
                {
                    var isbnAsString = isbn.Value;
                    if (context.Books.Any(b => b.Isbn == isbnAsString))
                    {
                        throw new ArgumentException("Such an ISBN already exists!");
                    }

                    currentBook.Isbn = isbnAsString;
                }

                var website = xmlBook.Element("web-site");
                if (website != null)
                {
                    currentBook.WebSite = website.Value;
                }

                var title = xmlBook.Element("title");
                if (title == null)
                {
                    throw new ArgumentException("Title cannot be null");
                }

                currentBook.Title = title.Value;

                var reviewsElement = xmlBook.Element("reviews");
                if (reviewsElement != null)
                {
                    var reviews = GetReviews(reviewsElement);

                    foreach (var review in reviews)
                    {
                        currentBook.Reviews.Add(review);
                    }
                }

                var authorsElement = xmlBook.Element("authors");
                if (authorsElement != null)
                {
                    var authorsXml = authorsElement.Elements("author");

                    foreach (var authorXml in authorsXml)
                    {
                        currentBook.Authors.Add(GetAuthor(authorXml.Value));
                    }
                }

                context.Books.Add(currentBook);
                context.SaveChanges();
            }
        }

        private static IEnumerable<Review> GetReviews(XElement reviewsElement)
        {
            var reviewsXml = reviewsElement.Elements("review");
            var reviewCollection = new List<Review>();

            foreach (var reviewXml in reviewsXml)
            {
                var review = new Review();
                review.Content = reviewXml.Value;
                var authorXml = reviewXml.Attribute("author");
                if (authorXml != null)
                {
                    var author = GetAuthor(authorXml.Value);
                    review.Author = author;
                }

                var dateXml = reviewXml.Attribute("date");
                if (dateXml != null)
                {
                    review.DateOfCreation = DateTime.Parse(dateXml.Value);
                }
                else
                {
                    review.DateOfCreation = DateTime.Now;
                }

                reviewCollection.Add(review);
            }

            return reviewCollection;
        }

        private static Author GetAuthor(string name)
        {
            var existingAuthor = context.Authors.Where(a => a.Name == name).FirstOrDefault();
            if (existingAuthor != null)
            {
                return existingAuthor;
            }

            return new Author() { Name = name };
        }
    }
}
