﻿using Cv.Business.Interface;
using Cv.Models;
using Cv.Business.Validations;
using Cv.Repository.Interface;
using System;
using Cv.Models.Enums;
using System.Threading.Tasks;
using Cv.Models.Helpers;
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
        public async Task<bool> Insert(CandidateModel candidate)
        {
            candidate.CandidateId = Guid.NewGuid().ToString();
            candidate.StarDate = DateTime.Now;
            if (Validator.ValidatePredicates(candidate, CandidateValidate.Predicates))
            {
                await candidatesRepository.Insert(candidate);
                return true;
            }
            return false;
        }
        public async Task<bool> Replace(CandidateModel candidate)
        {
            if (Validator.ValidatePredicates(candidate, CandidateValidate.Predicates))
                return await candidatesRepository.Replace(candidate);

            return false;
        }
        public async Task<bool> Delete(string companyId)
        {
            if (Validator.Guid(companyId))
                return await candidatesRepository.Delete(companyId);

            return false;
        }
        public async Task<CandidateModel> GetBy(string companyId, string candidateId)
        {
            if (Validator.Guid(companyId) && Validator.Guid(candidateId))
                return await candidatesRepository.GetBy(companyId, candidateId);

            return null;
        }
        public async Task<PagedListModel<CandidateModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name, int countryId, int stateId, StatusCandiateEnum? status = null)
        {
            if (Validator.Guid(companyId))
                return await candidatesRepository.GetBy(companyId, page, pageSize, name, countryId, stateId, status);

            return null;
        }
        public async Task<PagedListModel<CandidateModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null)
        {
            if (Validator.Guid(companyId))
                return await candidatesRepository.GetBy(companyId, page, pageSize, skills, countryId, stateId, status);

            return null;
        }
        public async Task<long> Count(string companyId, string name, int countryId, int stateId, StatusCandiateEnum? status = null)
        {
            if (Validator.Guid(companyId))
                return await candidatesRepository.Count(companyId, name, countryId, stateId, status);

            return 0;
        }
        public async Task<long> Count(string companyId, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null)
        {
            if (Validator.Guid(companyId))
                return await candidatesRepository.Count(companyId, skills, countryId, stateId, status);

            return 0;
        }

    }
}