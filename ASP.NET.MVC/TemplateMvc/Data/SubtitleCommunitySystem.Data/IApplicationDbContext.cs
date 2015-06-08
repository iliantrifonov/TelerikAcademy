namespace Data
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity;

    using Model;

    public interface IApplicationDbContext 
    {
        IDbSet<DbFile> Files { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
