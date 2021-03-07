using Cv.Business.Interface;
using Cv.Models;
using Cv.Business.Validations;
using Cv.Repository.Interface;
using System.Collections.Generic;
using System;
using Cv.Models.Enums;

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
            if (Validator.ValidatePredicates(candidate, CandidateValidate.Predicates))
            {
                candidatesRepository.Insert(candidate);
                return true;
            }
            return false;
        }
        public bool Replace(CandidateModel candidate)
        {
            if (Validator.ValidatePredicates(candidate, CandidateValidate.Predicates))
                return candidatesRepository.Replace(candidate);

            return false;
        }
        public bool Delete(string companyId)
        {
            if (Validator.Guid(companyId))
                return candidatesRepository.Delete(companyId);

            return false;
        }
        public List<CandidateModel> GetBy(string companyId,
            PageSizeEnum lines,
            string name = null,
            StatusCandiateEnum? status = null,
            int? countryId = null,
            int? stateId = null)
        {
            if (Validator.Guid(companyId))
                return candidatesRepository.GetBy(companyId, lines, name, status, countryId, stateId);

            return null;
        }
    }
}