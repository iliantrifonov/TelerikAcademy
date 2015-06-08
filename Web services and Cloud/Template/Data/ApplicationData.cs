namespace Data
{

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Data.Repositories;
    using Model;
    public class ApplicationData : IApplicationData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public ApplicationData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public ApplicationData()
            : this(new ApplicationDbContext())
        {

        }
        public IRepository<TestModelOne> Ones
        {
            get
            {
                return GetRepository<TestModelOne>();
            }
        }

        public IRepository<TestModelTwo> Twos
        {
            get
            {
                return GetRepository<TestModelTwo>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return GetRepository<ApplicationUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

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
