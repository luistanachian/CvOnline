using Cv.Business.Interface;
using Cv.Models;
using Cv.Business.Validations;
using Cv.Repository.Interface;
using System;
using Cv.Models.Enums;
using System.Threading.Tasks;
using Cv.Models.Helpers;
using System.Collections.Generic;
using Cv.Models.Items;

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
        public async Task<ResultBus> Insert(CandidateModel candidate)
        {
            var result = new ResultBus();
            try
            {
                candidate.CandidateId = Guid.NewGuid().ToString();
                candidate.StarDate = DateTime.Now;
                if (Validator.ValidatePredicates(candidate, CandidateValidate.Predicates, ref result))
                {
                    var insert = candidatesRepository.Insert(candidate);
                    await candidatesHistoriesBusiness.Insert(
                        candidate.CandidateId,
                        new EventItem
                        {
                            UserId = candidate.UserId,
                            Event = EventEnum.Insert,
                            Date = DateTime.Now
                        });

                    Task.WaitAll(insert);
                }
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
        }
        public async Task<ResultBus> Replace(CandidateModel candidate, string userID)
        {
            var result = new ResultBus();
            try
            {
                if (Validator.ValidatePredicates(candidate, CandidateValidate.Predicates, ref result))
                {
                    if (await candidatesRepository.Replace(candidate))
                    {
                        await candidatesHistoriesBusiness.Add(
                            candidate.CandidateId,
                            new EventItem
                            {
                                UserId = userID,
                                Event = EventEnum.Update,
                                Date = DateTime.Now
                            });
                    }
                    else
                        result.AddError("No se guardo");
                }
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
        }
        public async Task<ResultBus> Delete(string id)
        {
            var result = new ResultBus();
            try
            {
                if (!Validator.Guid(id) &&
                    !await candidatesRepository.Delete(id) && 
                    !await candidatesHistoriesBusiness.Delete(id))
                        result.AddError("No se Elimino");
            }
            catch (Exception) { result.AddError("Error"); }

            return result;
        }
        public async Task<CandidateModel> GetBy(string companyId, string candidateId)
        {
            if (Validator.Guid(companyId) && Validator.Guid(candidateId))
                return await candidatesRepository.GetBy(companyId, candidateId);

            return null;
        }
        public async Task<PagedListModel<CandidateModel>> GetBy(string companyId, int page, PageSizeEnum pageSize, string name, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null)
        {
            if (Validator.Guid(companyId))
                return await candidatesRepository.GetBy(companyId, page, pageSize, name, skills, countryId, stateId, status);

            return null;
        }
        public async Task<long> Count(string companyId, string name, List<string> skills, int countryId, int stateId, StatusCandiateEnum? status = null)
        {
            if (Validator.Guid(companyId))
                return await candidatesRepository.Count(companyId, name, skills, countryId, stateId, status);

            return 0;
        }
    }
}