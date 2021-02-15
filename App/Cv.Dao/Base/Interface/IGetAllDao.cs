﻿using System.Collections.Generic;

namespace Cv.Dao.Base.Interface
{
    public interface IGetAllDao<T> where T : class
    {
        List<T> GetAll();
    }
}