using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Cv.Business.Class
{
    public sealed class StatesBusiness : IStatesBusiness
    {

        private readonly IStatesRepository statesRepository;
        public StatesBusiness(IStatesRepository statesRepository)
        {
            this.statesRepository = statesRepository;
        }

        public List<StateModel> GetAllByCountryId(int id)
        {
            try
            {
                return statesRepository.GetAllByCountryId(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public StateModel GetByIdStateId(int id)
        {
            try
            {
                return statesRepository.GetByIdStateId(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}