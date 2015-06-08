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

    [RoutePrefix("api/articles")]
    public class LikesController : BaseApiController
    {
        public LikesController(IApplicationData data)
            : base(data)
        {

        }

        [HttpPost]
        [Route("like/{id}")]
        public IHttpActionResult PostLikeToArticleId(int id)
        {
            var article = this.data.Articles.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            var userID = this.User.Identity.GetUserId();

            if (article.Likes.Any(l => l.Author.Id == userID))
            {
                return BadRequest();
            }

            var author = this.data.Users.All()
                .FirstOrDefault(u => u.Id == userID);

            var like = new Like()
            {
                Article = article,
                Author = author
            };

            this.data.Likes.Add(like);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("like/{id}")]
        public IHttpActionResult UnlikeToArticleId(int id)
        {
            var article = this.data.Articles.Find(id);

            if (article == null)
            {
                return NotFound();
            }

            string userID = this.User.Identity.GetUserId();

            var like = article.Likes
                .FirstOrDefault(l => l.Author.Id == userID);

            if (like == null)
            {
                return BadRequest();
            }


            this.data.Likes.Delete(like.Id);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
