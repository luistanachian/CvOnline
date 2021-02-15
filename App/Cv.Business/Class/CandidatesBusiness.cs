using Cv.Business.Interface;
using Cv.Models;
using Cv.Business.Validations;
using Cv.Repository.Interface;
using System.Collections.Generic;

namespace Cv.Business.Class
{
    public sealed class CandidatesBusiness : ICandidatesBusiness
    {
        private readonly ICandidatesRepository candidatesRepository;
        public CandidatesBusiness(ICandidatesRepository candidatesRepository)
        {
            this.candidatesRepository = candidatesRepository;
        }
        public bool Insert(CandidateModel candidate)
        {
            if (CandidateValidate.IsOk(candidate))
            {
                candidatesRepository.Insert(candidate);
                return true;
            }
            return false;
        }
        public bool Replace(CandidateModel candidate) => candidatesRepository.Replace(candidate);
        public bool Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
                return candidatesRepository.Delete(id);

            return false;

        }
        public IList<CandidateModel> GetAllByCompanyId(string companyId) => candidatesRepository.GetAllByCompanyId(companyId);

    }
}
