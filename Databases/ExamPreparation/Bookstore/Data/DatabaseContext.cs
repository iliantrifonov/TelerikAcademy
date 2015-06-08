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

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}