using System;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using BugLogger.DataLayer;
using BugLogger.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugLogger.RestApi.Tests.Fakes;
using BugLogger.RestApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace BugLogger.RestApi.Tests
{
    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection()
        {
            //arrange

            var fakeRep = Mock.Create<IRepository<Bug>>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1"
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2"
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3"
                }
            };

            Mock.Arrange(() => fakeRep.All()).Returns(bugs.AsQueryable());

            var controller = new BugsController(fakeRep as IRepository<Bug>);

            //act

            var result = controller.GetAll();

            //assert

            CollectionAssert.AreEquivalent(bugs, result.ToList<Bug>());
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            //arrange
            var fakeRepo = new Moq.Mock<IRepository<Bug>>();
            var list = new List<Bug>();
            fakeRepo.Setup(r => r.Add(Moq.It.IsAny<Bug>())).Callback<Bug>(b => list.Add(b));
            fakeRepo.Setup(r => r.Save()).Verifiable();

            var bug = new Bug()
            {
                Text = "NEW TEST BUG"
            };
            var controller = new BugsController(fakeRepo.Object);
            this.SetupController(controller);

            //act
            controller.PostBug(bug);

            //assert
            Assert.AreEqual(list.Count, 1);
            var bugInDb =list.First();

            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LogDate);
            Assert.AreEqual(Status.Pending,bugInDb.Status);

            fakeRepo.Verify(r => r.Save());
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection_WithMocks()
        { 
            //arrange
            var repo = Mock.Create<IRepository<Bug>>();

            Bug[] bugs =
            {
                new Bug() { Text = "Bug1" },
                new Bug() { Text = "Bug2" }
            };

            Mock.Arrange(() => repo.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(repo);
            //act
            var result = controller.GetAll();

            //assert
            CollectionAssert.AreEquivalent(bugs, result.ToArray<Bug>());
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;
            
            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}