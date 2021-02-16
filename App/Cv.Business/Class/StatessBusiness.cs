using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
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

        public List<StateModel> GetAllByCountry(string code) => statesRepository.GetAllByCountry(code);
        public List<StateModel> GetAllByCountry(int id) => statesRepository.GetAllByCountry(id);
        public StateModel GetByIdState(int id) => statesRepository.GetByIdState(id);
        public StateModel GetByIdState(string code) => statesRepository.GetByIdState(code);
    }
}
