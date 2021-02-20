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

        public ResultBus<List<StateModel>> GetAllByCountry(int id)
        {
            var result = new ResultBus<List<StateModel>>();
            try
            {
                result.Object = statesRepository.GetAllByCountryId(id);
            }
            catch (Exception)
            {
                result.AddError("Error al consultar los estados.");
            }
            return result;
        }
        public ResultBus<StateModel> GetByIdState(int id)
        {
            var result = new ResultBus<StateModel>();
            try
            {
                result.Object = statesRepository.GetByIdState(id);
            }
            catch (Exception)
            {
                result.AddError("Error al consultar el estado.");
            }
            return result;
        }
    }
}
