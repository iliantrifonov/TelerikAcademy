using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Moq;
using Web.Controllers;
using System.Threading;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using Model;
using System.Web.Http.Routing;
using Web.DataModels;
namespace Web.Tests.Controllers
{
    [TestClass]
    public class ArticlesControllerTests
    {
        [TestMethod]
        public void GetAlla_WhenValid_ReturnsOkResponse()
        {
            // TODO :test for all constraints
            var fakeData = new Mock<IApplicationData>();
            List<Article> collection = GetArticles(1);
            fakeData.Setup(f => f.Articles.All()).Returns(collection.AsQueryable());

            var controller = new ArticlesController(fakeData.Object);

            SetupController(controller);

            var httpActionResult = controller.GetArticles();

            var response = httpActionResult.ExecuteAsync(CancellationToken.None).Result;


            Assert.IsTrue(response.Content.ReadAsAsync<IEnumerable<ArticleOutputDataModel>>().Result.Count() == 1);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        private List<Article> GetArticles(int count)
        {
            var articles = new List<Article>();

            for (int i = 0; i < count; i++)
            {
                var article = new Article()
                {
                    Content = "Some content",
                    Title = "title",
                    DateCreated = DateTime.Now.AddDays(-1),
                    Id = i + 1,
                    Category = new Category()
                    {
                        Id = i +1,
                        Name = "Some category"
                    },
                    
                };

                articles.Add(article);
            }

            return articles;
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
                        { "controller", "articles" }
                    });
        }
    }
}
