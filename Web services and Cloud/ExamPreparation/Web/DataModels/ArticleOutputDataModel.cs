namespace Web.DataModels
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class ArticleOutputDataModel
    {
        public ArticleOutputDataModel()
        {
            this.Tags = new HashSet<string>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime? DateCreated { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public static Expression<Func<Article, ArticleOutputDataModel>> ToOutputModel
        {
            get
            {
                return a => new ArticleOutputDataModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category.Name,
                    DateCreated = a.DateCreated,
                    Tags = a.Tags.Select(t => t.Name),
                };
            }
        }
    }
}