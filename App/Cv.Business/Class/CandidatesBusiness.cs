using Cv.Business.Interface;
using Cv.Models;
using Cv.Business.Validations;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System;

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
            candidate.CandidateId = Guid.NewGuid().ToString();
            candidate.StarDate = DateTime.Now;
            candidate.LastUpdate = DateTime.Now;
            if (Validator.ValidatePredicates(candidate, CandidateValidate.Predicates))
            {
                candidatesRepository.Insert(candidate);
                return true;
            }
            return false;
        }
        public bool Replace(CandidateModel candidate)
        {
            candidate.LastUpdate = DateTime.Now;
            if (Validator.ValidatePredicates(candidate, CandidateValidate.Predicates))
                return candidatesRepository.Replace(candidate);

            return false;
        }
        public bool Delete(string id)
        {
            if (Validator.Guid(id))
                return candidatesRepository.Delete(id);

            return false;
        }
        public List<CandidateModel> GetAllByCompanyId(string companyId)
        {
            //if (Validator.Guid(companyId))
            //    return candidatesRepository.GetAllByCompanyId(companyId);

            return null;

        }
    }
}