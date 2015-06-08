namespace Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using Model;

    public class ArticleDetailedOutputModel
    {
        public ArticleDetailedOutputModel()
        {
            this.Tags = new HashSet<string>();
            this.Likes = new HashSet<int>();
            this.Comments = new HashSet<CommentOutputDataModel>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime? DateCreated { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<int> Likes { get; set; }

        public IEnumerable<CommentOutputDataModel> Comments { get; set; }

        public static Expression<Func<Article, ArticleDetailedOutputModel>> ToOutputModel
        {
            get
            {
                return a => new ArticleDetailedOutputModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category.Name,
                    DateCreated = a.DateCreated,
                    Tags = a.Tags.Select(t => t.Name),
                    Likes = a.Likes.Select(l => l.Id),
                    Comments = a.Comments
                        .AsQueryable()
                        .Select(CommentOutputDataModel.ToDataModel),
                };
            }
        }
    }
}