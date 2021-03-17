using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;
using Cv.Models.Enums;
using System.Threading.Tasks;
using Cv.Models.Helpers;
using System.Collections.Generic;
using Cv.Models.Items;
using Cv.Commons;
using System.Net;

namespace Cv.Business.Class
{
    public sealed class CandidatesBusiness : ICandidatesBusiness
    {
        private readonly ICandidatesRepository candidatesRepository;
        private readonly ICandidatesHistoriesBusiness candidatesHistoriesBusiness;
        public CandidatesBusiness(ICandidatesRepository candidatesRepository, ICandidatesHistoriesBusiness candidatesHistoriesBusiness)
        {
            this.candidatesRepository = candidatesRepository;
            this.candidatesHistoriesBusiness = candidatesHistoriesBusiness;
        }
        public async Task<HttpStatusCode> Save(string userId, CandidateModel candidate)
        {
            try
            {
                CandidateModel candidateTemp = null;

                if (Validate.Guids(candidate.CandidateId))
                    candidateTemp = await GetBy(candidate.CompanyId, candidate.CandidateId);

                if (candidateTemp == null)
                {
                    if (string.IsNullOrWhiteSpace(candidate.CandidateId))
                    {
                        candidate.CandidateId = Guid.NewGuid().ToString();
                        candidate.Status = (int)StatusCandiateEnum.Available;
                        candidate.Sex = candidate.Sex?.ToLower();

                        var insert = candidatesRepository.Insert(candidate);
                        await candidatesHistoriesBusiness.Add(candidate.CandidateId, new EventItem(userId, EventEnum.Insert));
                        Task.WaitAll(insert);
                        return HttpStatusCode.OK;
                    }
                    return HttpStatusCode.NotFound; 
                }
                else
                {
                    if (await candidatesRepository.Replace(candidate))
                    {
                        try { await candidatesHistoriesBusiness.Add(candidate.CandidateId, new EventItem(userId, EventEnum.Update)); } catch (Exception) { }
                        return HttpStatusCode.OK;
                    }
                    return HttpStatusCode.NotModified;
                }
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
        public async Task<HttpStatusCode> Delete(string companyId, string candidateId)
        {
            try
            {
                if (await candidatesRepository.Delete(companyId, candidateId))
                {
                    try { await candidatesHistoriesBusiness.Delete(candidateId); } catch (Exception) { }
                    return HttpStatusCode.OK;
                }
                return HttpStatusCode.NotFound;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
        public async Task<CandidateModel> GetBy(string companyId, string candidateId)
        {
            return await candidatesRepository.GetBy(companyId, candidateId);
        }
        public async Task<PagedListModel<CandidateModel>> GetBy(string companyId, int page, int pageSize, string name, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null)
        {
            return await candidatesRepository.GetBy(companyId, page, pageSize, name, skills, countryId, stateId, status);
        }
        public async Task<long> Count(string companyId, string name, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null)
        {

            return await candidatesRepository.Count(companyId, name, skills, countryId, stateId, status);

        }
    }
}