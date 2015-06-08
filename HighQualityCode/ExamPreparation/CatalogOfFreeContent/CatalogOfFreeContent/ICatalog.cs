namespace CatalogOfFreeContent
{
    using System.Collections.Generic;

    public interface ICatalog
    {
        /// <summary>
        /// Adds the content to the catalog
        /// </summary>
        /// <param name="content">A non null content to be added</param>
        void Add(IContent content);

        /// <summary>
        /// Gets an IEnumerable<IContent> matching the title and with the count from below.
        /// </summary>
        /// <param name="title">The title of the element that will be matched when getting the IContent</param>
        /// <param name="numberOfContentElementsToList">The count of the elements that will be returned ( if the number is larger than the actual count of elements inside the catalog, it will return all of the elements.</param>
        /// <returns></returns>
        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        /// <summary>
        /// Changes the Urls of all elements that match the given Url
        /// </summary>
        /// <param name="oldUrl">The Url that will be replaced.</param>
        /// <param name="newUrl">The replacing Url.</param>
        /// <returns></returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
