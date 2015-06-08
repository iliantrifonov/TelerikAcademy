namespace CatalogOfFreeContent.Test.Catalog
{
    using CatalogOfFreeContent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class UpdateContentTests
    {
        [TestMethod]
        public void UpdateOneItemGivesOne()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            itemMock.Setup(c => c.Url).Returns("someUrl");
            catalogue.Add(itemMock.Object);

            var updatedCount = catalogue.UpdateContent("someUrl", "newUrl4");

            Assert.AreEqual(1, updatedCount);
        }

        [TestMethod]
        public void UpdateTwoItemGivesTwo()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            itemMock.Setup(c => c.Url).Returns("someUrl");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title");
            itemMock2.Setup(c => c.Url).Returns("someUrl");
            catalogue.Add(itemMock2.Object);

            var updatedCount = catalogue.UpdateContent("someUrl", "newUrl4");

            Assert.AreEqual(2, updatedCount);
        }

        [TestMethod]
        public void UpdateTwoMatchedItemWithOthersNonMatchingGivesTwo()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            itemMock.Setup(c => c.Url).Returns("someUrl");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title");
            itemMock2.Setup(c => c.Url).Returns("someUrl");
            catalogue.Add(itemMock2.Object);

            var itemMock3 = new Mock<IContent>();
            itemMock3.Setup(c => c.Title).Returns("title");
            itemMock3.Setup(c => c.Url).Returns("someUrl1");
            catalogue.Add(itemMock3.Object);

            var itemMock4 = new Mock<IContent>();
            itemMock4.Setup(c => c.Title).Returns("title");
            itemMock4.Setup(c => c.Url).Returns("someUrl2");
            catalogue.Add(itemMock4.Object);

            var updatedCount = catalogue.UpdateContent("someUrl", "newUrl4");

            Assert.AreEqual(2, updatedCount);
        }

        [TestMethod]
        public void UpdateNoMatchedItemWithOthersNonMatchingGivesZero()
        {
            var catalogue = new Catalog();
            var itemMock = new Mock<IContent>();
            itemMock.Setup(c => c.Title).Returns("title");
            itemMock.Setup(c => c.Url).Returns("someUrl");
            catalogue.Add(itemMock.Object);

            var itemMock2 = new Mock<IContent>();
            itemMock2.Setup(c => c.Title).Returns("title");
            itemMock2.Setup(c => c.Url).Returns("someUrl");
            catalogue.Add(itemMock2.Object);

            var itemMock3 = new Mock<IContent>();
            itemMock3.Setup(c => c.Title).Returns("title");
            itemMock3.Setup(c => c.Url).Returns("someUrl1");
            catalogue.Add(itemMock3.Object);

            var itemMock4 = new Mock<IContent>();
            itemMock4.Setup(c => c.Title).Returns("title");
            itemMock4.Setup(c => c.Url).Returns("someUrl2");
            catalogue.Add(itemMock4.Object);

            var updatedCount = catalogue.UpdateContent("someUrl3", "newUrl");

            Assert.AreEqual(0, updatedCount);
        }
    }
}
