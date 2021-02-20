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

        public ResultBus<List<StateModel>> GetAllByCountryId(int id)
        {
            var result = new ResultBus<List<StateModel>>();
            try
            {
                result.Object = statesRepository.GetAllByCountryId(id);

                if (result.Object == null || result.Object.Count == 0)
                    result.AddError("No se encontraron los estados.");
            }
            catch (Exception)
            {
                result.AddError("Error al consultar los estados.");
            }
            return result;
        }
        public ResultBus<StateModel> GetByIdStateId(int id)
        {
            var result = new ResultBus<StateModel>();
            try
            {
                result.Object = statesRepository.GetByIdStateId(id);

                if (result.Object == null)
                    result.AddError("No se encontro el estado.");
            }
            catch (Exception)
            {
                result.AddError("Error al consultar el estado.");
            }
            return result;
        }
    }
}