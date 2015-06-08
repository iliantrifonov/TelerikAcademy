﻿using System;
using System.Linq;
using System.Linq.Expressions;
namespace Albums.Data.Repositories
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        void Detach(T entity);

        void SaveChange();
    }
}
