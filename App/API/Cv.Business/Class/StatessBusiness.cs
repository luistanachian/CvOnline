using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv.Business.Class
{
    public sealed class StatesBusiness : IStatesBusiness
    {

        private readonly IStatesRepository statesRepository;
        public StatesBusiness(IStatesRepository statesRepository)
        {
            this.statesRepository = statesRepository;
        }

        public async Task<List<ComboResponse>> GetAllByCountryId(int id)
        {
            try
            {
                return await statesRepository.GetAllByCountryId(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<StateModel> GetByIdStateId(int id)
        {
            try
            {
                return await statesRepository.GetByIdStateId(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}