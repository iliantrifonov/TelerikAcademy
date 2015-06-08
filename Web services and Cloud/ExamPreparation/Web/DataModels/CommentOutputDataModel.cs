namespace Web.DataModels
{
    using System;
    using System.Linq.Expressions;

    using Model;

    public class CommentOutputDataModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? DateCreated { get; set; }

        public string AuthorName { get; set; }

        public static Expression<Func<Comment, CommentOutputDataModel>> ToDataModel
        {
            get
            {
                return c => new CommentOutputDataModel()
                {
                    Id = c.Id,
                    DateCreated = c.DateCreated,
                    AuthorName = c.Author.UserName,
                    Content = c.Content
                };
            }
        }
    }
}
