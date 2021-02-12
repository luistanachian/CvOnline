﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cv.Dao.Interface
{
    public interface IBaseDaoMongoDb<T> where T : class
    {
        IList<T> GetAll();
        T GetOneByFunc(Expression<Func<T, bool>> filter);
        IList<T> GetListByFunc(Expression<Func<T, bool>> filter, int? top = null);
        void Insert(T entity);
        void InsertMany(List<T> listEntity);
        long Update(Expression<Func<T, bool>> filter, T entity);
        long Delete(Expression<Func<T, bool>> filter);
    }
}
