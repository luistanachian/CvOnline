﻿using Cv.Models;

namespace Cv.Repository.Interface
{
    public interface ICompaniesStatisticsRepository
    {
        void Insert(CompanyStatisticsModel entity);
        public bool Replace(CompanyStatisticsModel entity);
        public bool Delete(string companyId);
        public CompanyStatisticsModel GetBy(string companyId);
    }
}