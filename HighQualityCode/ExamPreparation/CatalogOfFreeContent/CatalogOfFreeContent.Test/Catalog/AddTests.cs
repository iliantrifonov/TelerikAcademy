namespace CatalogOfFreeContent.Test.Catalog
{
    using System.Linq;
    using CatalogOfFreeContent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void AddingOneItemPutsItInside()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);
            var actualCount = catalogue.GetListContent("title", 5).Count();

            Assert.AreEqual(1, actualCount);
        }

        [TestMethod]
        public void AddingTwoDifferentItemsPutsItInside()
        {
            var catalogue = new Catalog();

            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("not");
            catalogue.Add(itemMock2.Object);

            var actualCount = catalogue.GetListContent("title", 5).Count();

            Assert.AreEqual(1, actualCount);

            actualCount = catalogue.GetListContent("not", 5).Count();

            Assert.AreEqual(1, actualCount);
        }

        [TestMethod]
        public void AddingTwoSameTitleItemsPutsItInside()
        {
            var catalogue = new Catalog();

            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock2.Object);

            var actualCount = catalogue.GetListContent("title", 5).Count();

            Assert.AreEqual(2, actualCount);
        }

        [TestMethod]
        public void AddingManySameAndDifferentItemsPutsItInside()
        {
            var catalogue = new Catalog();

            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);

            var itemMock3 = new Mock<IContent>();
            itemMock3.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock3.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("not");
            catalogue.Add(itemMock2.Object);

            var itemMock4 = new Mock<IContent>();
            itemMock4.Setup(c => c.Title).Returns("hot");
            catalogue.Add(itemMock4.Object);

            var actualCount = catalogue.GetListContent("title", 5).Count();

            Assert.AreEqual(2, actualCount);

            actualCount = catalogue.GetListContent("not", 5).Count();

            Assert.AreEqual(1, actualCount);

            actualCount = catalogue.GetListContent("hot", 5).Count();

            Assert.AreEqual(1, actualCount);
        }
    }
}
