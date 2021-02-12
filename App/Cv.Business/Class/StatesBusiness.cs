using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
using System.Collections.Generic;

namespace Cv.Business.Class
{
    public class StatesBusiness : IStatesBusiness
    {
        private readonly IStatesRepository statesRepository;
        public StatesBusiness(IStatesRepository statesRepository)
        {
            this.statesRepository = statesRepository;
        }

        public IList<StateModel> GetAllByCountry(string codeCountry) => statesRepository.GetAllByCountry(codeCountry);
        public StateModel GetByIdState(string idState) => statesRepository.GetByIdState(idState);
    }
}
