using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Items;
using Cv.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Business.Class
{
    public class CandidatesHistoriesBusiness : ICandidatesHistoriesBusiness
    {
        private readonly ICandidatesHistoriesRepository candidatesHistoriesRepository;
        public CandidatesHistoriesBusiness(ICandidatesHistoriesRepository candidatesHistoriesRepository)
        {
            this.candidatesHistoriesRepository = candidatesHistoriesRepository;
        }

        public async Task<bool> Add(string candidateId, EventItem eventItem)
        {
            try
            {
                var his = await candidatesHistoriesRepository.GetBy(candidateId);
                if (his != null && his.CandidateId == candidateId)
                {
                    his.History.Add(eventItem);
                    return await candidatesHistoriesRepository.Replace(his);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> Insert(string candidateID, EventItem eventItem)
        {
            try
            {
                await candidatesHistoriesRepository.Insert(new CandidateHistoryModel
                {
                    CandidateId = candidateID,
                    History = new List<EventItem> { eventItem }
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> Delete(string id) =>
            await candidatesHistoriesRepository.Delete(id);

        public async Task<CandidateHistoryModel> GetBy(string candidateId) => 
            await candidatesHistoriesRepository.GetBy(candidateId);
    }
}