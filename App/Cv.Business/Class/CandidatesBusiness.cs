using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;
using Cv.Models.Enums;
using System.Threading.Tasks;
using Cv.Models.Helpers;
using Cv.Models.Items;
using Cv.Commons;
using System.Net;
using Cv.Models.Search;

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
            HttpStatusCode httpStatusCode = HttpStatusCode.NotModified;
            try
            {
                candidate.CandidateId = string.IsNullOrWhiteSpace(candidate.CandidateId) ? null : candidate.CandidateId;
                EventItem eventItem = new(userId, EventEnum.Insert);
                CandidateModel candidateTemp = null;

                if (Validate.Guids(candidate.CandidateId))
                    candidateTemp = await GetBy(candidate.CompanyId, candidate.CandidateId);

                if (candidateTemp == null && candidate.CandidateId == null)
                {
                    candidate.CandidateId = Guid.NewGuid().ToString();
                    candidate.Status = (int)StatusCandiateEnum.Available;
                    candidate.Sex = candidate.Sex?.ToLower();

                    await candidatesRepository.Insert(candidate);
                    httpStatusCode = HttpStatusCode.OK;
                }
                else if ((await candidatesRepository.Replace(candidate)))
                {
                    eventItem.Event = EventEnum.Update;
                    httpStatusCode = HttpStatusCode.OK;
                }

                if (httpStatusCode == HttpStatusCode.OK)
                    await candidatesHistoriesBusiness.Add(candidate.CandidateId, eventItem);

                return httpStatusCode;
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
                return HttpStatusCode.NotModified;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
        public async Task<CandidateModel> GetBy(string companyId, string candidateId)
        {
            try
            {
                return await candidatesRepository.GetBy(companyId, candidateId);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<PagedListModel<CandidateModel>> GetBy(CandidateSearch candidateSearch)
        {
            try
            {
                return await candidatesRepository.GetBy(candidateSearch);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<long> Count(CandidateSearch candidateSearch)
        {
            try
            {
                return await candidatesRepository.Count(candidateSearch);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}