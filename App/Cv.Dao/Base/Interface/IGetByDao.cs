﻿using Cv.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cv.Dao.Base.Interface
{
    public interface IGetByDao<T> where T : class
    {
        T GetOneByFunc(Expression<Func<T, bool>> filter);
        List<T> GetListByFunc(Expression<Func<T, bool>> filter, LinesEnum lines);
        long GetCount(Expression<Func<T, bool>> filter);
    }
}
