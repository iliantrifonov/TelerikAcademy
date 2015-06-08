namespace Data
{
    using System;
    using System.Linq;

    using Data.Repositories;
    using Model;

    public interface IApplicationData
    {
        IApplicationDbContext Context { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<DbFile> Files { get; }

        int SaveChanges();

        //bool RemoveRoleFromUser(ApplicationUser user, string roleName);

        //bool AddRoleToUser(ApplicationUser user, string role);
    }
}
