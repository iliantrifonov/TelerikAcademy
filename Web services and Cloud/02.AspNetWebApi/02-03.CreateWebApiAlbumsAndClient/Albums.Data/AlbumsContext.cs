namespace Albums.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Albums.Data.Migrations;
    using Albums.Models;

    public class AlbumsContext : DbContext, IAlbumsContext
    {
        public AlbumsContext()
            : base("name=AlbumsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AlbumsContext, Configuration>());
        }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}