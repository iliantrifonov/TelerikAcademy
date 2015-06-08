namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data.Repositories;
    using Model;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    public class ApplicationData : IApplicationData
    {
        private IApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public ApplicationData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public ApplicationData() : this(new ApplicationDbContext())
        {
        }

        public IApplicationDbContext Context
        {
            get
            {
                return this.context;
            }
        }
        
        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<DbFile> Files
        {
            get
            {
                return this.GetRepository<DbFile>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        //public bool AddRoleToUser(ApplicationUser user, string role)
        //{
        //    try
        //    {
        //        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.context.DbContext));
        //        userManager.AddToRole(user.Id, role);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //public bool RemoveRoleFromUser(ApplicationUser user, string roleName)
        //{
        //    var identityContext = this.context as IdentityDbContext<ApplicationUser>;
        //    var role = identityContext.Roles.FirstOrDefault(r => r.Name == roleName);
        //    if (role == null)
        //    {
        //        return false;
        //    }

        //    var roleId = role.Id;
        //    try
        //    {
        //        var roleInUser = user.Roles.FirstOrDefault(r => r.RoleId == roleId);
        //        user.Roles.Remove(roleInUser);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
