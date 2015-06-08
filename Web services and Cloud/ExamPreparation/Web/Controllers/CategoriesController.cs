namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Data;
    using DataModels;

    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IApplicationData data)
            : base(data)
        {

        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var categories = this.data.Categories.All()
                .Select(CategoryOutputDataModel.ToDataModel);

            return Ok(categories);
        }

        [HttpGet]
        public IHttpActionResult GetArticlesByCategoryId(int id)
        {
            var articles = this.data.Articles.All()
                .Where(a => a.Category.Id == id)
                .OrderBy(a => a.DateCreated)
                .Select(ArticleOutputDataModel.ToOutputModel);

            return Ok(articles);
        }
    }
}
