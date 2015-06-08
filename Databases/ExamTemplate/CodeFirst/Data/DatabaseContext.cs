namespace Data
{
    using Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=SQLContext")
        {
            Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        public DatabaseContext(string connectionName) : base(connectionName)
        {
            Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}