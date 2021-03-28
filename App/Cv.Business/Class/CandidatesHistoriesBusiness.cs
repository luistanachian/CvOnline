using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
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
            var his = await candidatesHistoriesRepository.GetBy(candidateId);
            if (his == null)
            {
                eventItem.Event = EventEnum.Insert;
                await candidatesHistoriesRepository.Insert(new CandidateHistoryModel
                {
                    CandidateId = candidateId,
                    History = new List<EventItem> { eventItem }
                });
                return true;
            }
            his.History.Add(eventItem);
            return await candidatesHistoriesRepository.Replace(his);
        }

        public async Task<bool> Delete(string id) =>
            await candidatesHistoriesRepository.Delete(id);

        public async Task<CandidateHistoryModel> GetBy(string candidateId) =>
            await candidatesHistoriesRepository.GetBy(candidateId);
    }
}