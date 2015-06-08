namespace Albums.Data
{
    using System;

    using Albums.Data.Repositories;
    using Albums.Models;

    public interface IAlbumsData
    {
        IGenericRepository<Song> Songs { get; }

        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Album> Albums { get; }

        void SaveChanges();

        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}