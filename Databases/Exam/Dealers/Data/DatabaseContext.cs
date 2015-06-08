namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data.Migrations;
    using Model;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=SQLContext")
        {
            Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        public DatabaseContext(string connectionName)
            : base(connectionName)
        {
            Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}