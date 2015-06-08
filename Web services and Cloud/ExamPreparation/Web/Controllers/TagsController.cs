
namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Data;
    using Model;
    using DataModels;

    public class TagsController : BaseApiController
    {
        public TagsController(IApplicationData data)
            : base(data)
        {

        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var tags = this.data.Tags.All()
                .Select(TagOutputDataModel.ToDataModel);

            return Ok(tags);
        }

        [HttpGet]
        public IHttpActionResult GetArticlesByTagId(int id)
        {
            var tag = this.data.Tags.Find(id);

            if (tag == null)
            {
                return NotFound();
            }
            var articles = tag.Articles.AsQueryable()
                .Select(ArticleOutputDataModel.ToOutputModel);

            return Ok(articles);
        }
    }
}
