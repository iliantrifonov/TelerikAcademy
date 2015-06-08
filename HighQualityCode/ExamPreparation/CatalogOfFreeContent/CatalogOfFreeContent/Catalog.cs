namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private readonly MultiDictionary<string, IContent> contentByUrl;
        private readonly OrderedMultiDictionary<string, IContent> contentByTitle;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.contentByTitle = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.contentByUrl = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.contentByTitle.Add(content.Title, content);
            this.contentByUrl.Add(content.Url, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from content in this.contentByTitle[title] select content;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            List<IContent> contentToList = this.contentByUrl[oldUrl].ToList();

            // TODO : This seems very inefficient
            foreach (var content in contentToList)
            {
                this.contentByTitle.Remove(content.Title, content);
            }

            this.contentByUrl.Remove(oldUrl);

            foreach (var content in contentToList)
            {
                content.Url = newUrl;
            }

            foreach (var content in contentToList)
            {
                this.contentByTitle.Add(content.Title, content);
                this.contentByUrl.Add(content.Url, content);
            }

            return contentToList.Count;
        }
    }
}