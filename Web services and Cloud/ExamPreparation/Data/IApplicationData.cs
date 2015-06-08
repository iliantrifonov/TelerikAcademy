namespace Data
{
    using System;
    using System.Linq;

    using Data.Repositories;
    using Model;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Article> Articles { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }
        
        IRepository<Like> Likes { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
