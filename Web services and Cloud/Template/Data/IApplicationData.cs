namespace Data
{
    using System;
    using System.Linq;

    using Data.Repositories;
    using Model;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<TestModelOne> Ones { get; }

        IRepository<TestModelTwo> Twos { get; }

        int SaveChanges();
    }
}
