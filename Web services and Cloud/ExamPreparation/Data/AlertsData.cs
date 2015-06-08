namespace Data
{
    using Data.Repositories;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AlertsData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public AlertsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public AlertsData()
            : this(new ApplicationDbContext())
        {

        }

        public IRepository<Alert> Alerts
        {
            get
            {
                return GetRepository<Alert>();
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
