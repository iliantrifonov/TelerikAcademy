namespace UploadZipToDb
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using UploadZipToDb.Migrations;

    public class UploadDbContext : DbContext
    {
        public UploadDbContext()
            : base("name=UploadDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UploadDbContext, Configuration>());
        }

        public virtual DbSet<UploadedTextFile> Files { get; set; }
    }
}