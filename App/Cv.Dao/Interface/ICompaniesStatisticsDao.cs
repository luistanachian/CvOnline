﻿using Cv.Dao.Base.Interface;
using Cv.Models;

namespace Cv.Dao.Interface
{
    public interface ICompaniesStatisticsDao :
        IGetByDao<CompanyStatisticsModel>,
        IInsertDao<CompanyStatisticsModel>,
        IUpdateDao<CompanyStatisticsModel>,
        IDeleteDao<CompanyStatisticsModel>
    {
    }
}
