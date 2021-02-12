using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;

namespace Cv.Business.Class
{
    public class CandidatesBusiness : ICandidatesBusiness
    {
        private readonly ICandidatesRepository candidatesRepository;
        public CandidatesBusiness(ICandidatesRepository candidatesRepository)
        {
            this.candidatesRepository = candidatesRepository;
        }
        public void Insert(CandidateModel candidate) => candidatesRepository.Insert(candidate);
        public void InsertMany(List<CandidateModel> listCandidate) => candidatesRepository.InsertMany(listCandidate);
        public bool Update(CandidateModel candidate) => candidatesRepository.Update(candidate);
        public bool Delete(string id) => candidatesRepository.Delete(id);
        public IList<CandidateModel> GetAllByCompanyId(string companyId) => candidatesRepository.GetAllByCompanyId(companyId);

    }
}
