﻿using Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repos
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        T Find(Expression<Func<T, bool>> match);
        List<T> FindAll(Expression<Func<T, bool>> match);
        T Insert(T entity);
        bool BulkInsert(List<T> entities);
        T Update(T entity);
        int Delete(T entity);
    }
}
