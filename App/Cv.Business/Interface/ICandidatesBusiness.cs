﻿using Cv.Models;
using System.Collections.Generic;

namespace Cv.Business.Interface
{
    public interface ICandidatesBusiness
    {
        bool Insert(CandidateModel candidated);
        bool Replace(CandidateModel candidate);
        bool Delete(string id);
        List<CandidateModel> GetAllByCompanyId(string companyId, int top);
    }
}
