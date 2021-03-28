using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;
using System.Threading.Tasks;
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
            var httpStatusCode = HttpStatusCode.NotModified;

            candidate.CandidateId = string.IsNullOrWhiteSpace(candidate.CandidateId) ? null : candidate.CandidateId;
            EventItem eventItem = new(userId, EventEnum.Insert);
            CandidateModel candidateTemp = null;

            if (Validate.Guids(candidate.CandidateId))
                candidateTemp = await GetBy(candidate.CompanyId, candidate.CandidateId);

            if (candidateTemp == null && candidate.CandidateId == null)
            {
                candidate.CandidateId = Guid.NewGuid().ToString();
                candidate.Status = (int)StatusCandiateEnum.Available;
                candidate.PersonalData.Sex = candidate.PersonalData.Sex?.ToLower();

                await candidatesRepository.Insert(candidate);
                httpStatusCode = HttpStatusCode.OK;
            }
            else if (await candidatesRepository.Replace(candidate))
            {
                eventItem.Event = EventEnum.Update;
                httpStatusCode = HttpStatusCode.OK;
            }

            if (httpStatusCode == HttpStatusCode.OK)
                await candidatesHistoriesBusiness.Add(candidate.CandidateId, eventItem);

            return httpStatusCode;
        }
        public async Task<HttpStatusCode> Delete(string companyId, string candidateId)
        {
            if (await candidatesRepository.Delete(companyId, candidateId))
            {
                try { await candidatesHistoriesBusiness.Delete(candidateId); } catch (Exception) { }
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NotModified;
        }
        public async Task<CandidateModel> GetBy(string companyId, string candidateId) =>
            await candidatesRepository.GetBy(companyId, candidateId);

        public async Task<PagedListModel<CandidateModel>> GetBy(CandidateSearch candidateSearch) =>
            await candidatesRepository.GetBy(candidateSearch);

        public async Task<long> Count(CandidateSearch candidateSearch) =>
            await candidatesRepository.Count(candidateSearch);
    }
}