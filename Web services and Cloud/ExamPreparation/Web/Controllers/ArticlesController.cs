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
    using Web.DataModels;

    public class ArticlesController : BaseApiController
    {
        private const int PageAmount = 10;

        public ArticlesController(IApplicationData data)
            : base(data)
        {

        }

        //[Authorize]
        [HttpPost]
        public IHttpActionResult PostArticle([FromBody]ArticleInputDataModel model)
        {
            if (model == null ||!this.ModelState.IsValid)
            {
                return BadRequest();    
            }

            var category = this.data.Categories.All().FirstOrDefault(c => c.Name == model.Category);
            if (category == null)
            {
                category = new Category()
                {
                    Name = model.Category,
                };

                this.data.Categories.Add(category);
            }

            var tags = GetTags(model);

            var articleForDb = new Article()
            {
                AuthorID = this.User.Identity.GetUserId(),
                Category = category,
                Content = model.Content,
                DateCreated = DateTime.Now,
                Title = model.Title,
                Tags = tags,
            };

            this.data.Articles.Add(articleForDb);

            this.data.SaveChanges();

            var outputModel = this.data.Articles.All()
                .Where(a => a.Id == articleForDb.Id)
                .Select(ArticleOutputDataModel.ToOutputModel);

            return Ok(outputModel);
        }

        [HttpGet]
        public IHttpActionResult GetArticles(int page, string category)
        {
            var articlesToReturn = this.GetSortedArticles()
                .Where(c => category == null ? true : category == c.Category.Name)
                .Skip(PageAmount * page)
                .Take(PageAmount)
                .Select(ArticleOutputDataModel.ToOutputModel);

            return Ok(articlesToReturn);
        }

        [HttpGet]
        public IHttpActionResult GetDetailedArticlesById(int id)
        {
            var articleToReturn = this.data.Articles.All()
                .Select(ArticleDetailedOutputModel.ToOutputModel)
                .FirstOrDefault(a => a.Id == id);

            if (articleToReturn == null)
            {
                return NotFound();
            }

            return Ok(articleToReturn);
        }

        [HttpGet]
        public IHttpActionResult GetArticles()
        {
            return this.GetArticles(0, null);
        }

        [HttpGet]
        public IHttpActionResult GetArticles(int page)
        {
            return this.GetArticles(page, null);
        }

        [NonAction]
        private IQueryable<Article> GetSortedArticles()
        {
            return this.data.Articles.All().OrderBy(a => a.DateCreated);
        }

        private ICollection<Tag> GetTags(ArticleInputDataModel model)
        {
            var titletgas = model.Title.Split(' ');
            var allTags = new HashSet<string>(titletgas);

            foreach (var modelTag in model.Tags)
            {
                allTags.Add(modelTag);
            }

            var articleTags = new HashSet<Tag>();
            foreach (var tagName in allTags)
            {
                var tag = this.data.Tags.All()
                .FirstOrDefault(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = new Tag { Name = tagName };
                    this.data.Tags.Add(tag);
                }

                articleTags.Add(tag);
            }

            return articleTags;
        }
    }
}
