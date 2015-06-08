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

    [RoutePrefix("api")]
    public class CommentController : BaseApiController
    {
        public CommentController(IApplicationData data) : base(data)
        {

        }

        [HttpPost]
        [Route("articles/{id}/comments")]
        public IHttpActionResult PostComment([FromUri]int id, [FromBody]CommentInputDataModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return BadRequest();
            }

            var article = this.data.Articles.All()
                .FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            var userId = this.User.Identity.GetUserId();
            
            var author = this.data.Users.All()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            var comment = new Comment()
            {
                Author = author,
                Article = article,
                Content = model.Content,
                DateCreated = DateTime.Now,
            };

            this.data.Comments.Add(comment);
            this.data.SaveChanges();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, model);

            return ResponseMessage(response);
        }
    }
}
