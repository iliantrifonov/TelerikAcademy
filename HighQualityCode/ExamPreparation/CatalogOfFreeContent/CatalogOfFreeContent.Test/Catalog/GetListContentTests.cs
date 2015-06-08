namespace CatalogOfFreeContent.Test.Catalog
{
    using System;
    using System.Linq;
    using CatalogOfFreeContent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class GetListContentTests
    {
        [TestMethod]
        public void GetOneElementWithOneAdded()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);
            var actualCount = catalogue.GetListContent("title", 1).Count();

            Assert.AreEqual(1, actualCount);
        }

        [TestMethod]
        public void GetZeroElementWithOneAddedZeroMatched()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);
            var actualCount = catalogue.GetListContent("title2", 1).Count();

            Assert.AreEqual(0, actualCount);
        }

        [TestMethod]
        public void GetZeroElementWithManyAddedZeroMatched()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title2");
            catalogue.Add(itemMock2.Object);

            var itemMock3 = new Mock<IContent>();
            itemMock3.Setup(c => c.Title).Returns("title3");
            catalogue.Add(itemMock3.Object);

            var actualCount = catalogue.GetListContent("title4", 1).Count();

            Assert.AreEqual(0, actualCount);
        }

        [TestMethod]
        public void GetZeroElementWithOneAddedManyMatched()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock2.Object);

            var itemMock3 = new Mock<IContent>();
            itemMock3.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock3.Object);

            var actualCount = catalogue.GetListContent("title", 0).Count();

            Assert.AreEqual(0, actualCount);
        }

        [TestMethod]
        public void GetOneElementWithOneAddedManyMatched()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock2.Object);

            var itemMock3 = new Mock<IContent>();
            itemMock3.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock3.Object);

            var actualCount = catalogue.GetListContent("title", 1).Count();

            Assert.AreEqual(1, actualCount);
        }

        [TestMethod]
        public void GetTwoElementWithTwoAddedManyMatched()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock2.Object);

            var itemMock3 = new Mock<IContent>();
            itemMock3.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock3.Object);

            var actualCount = catalogue.GetListContent("title", 2).Count();

            Assert.AreEqual(2, actualCount);
        }

        [TestMethod]
        public void GetMoreThanAddedElementWithFourAddedThreeMatched()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock2.Object);

            var itemMock3 = new Mock<IContent>();
            itemMock3.Setup(c => c.Title).Returns("title");
            catalogue.Add(itemMock3.Object);

            var itemMock4 = new Mock<IContent>();
            itemMock4.Setup(c => c.Title).Returns("title2");
            catalogue.Add(itemMock4.Object);

            var actualCount = catalogue.GetListContent("title", 10).Count();

            Assert.AreEqual(3, actualCount);
        }
    }
}
