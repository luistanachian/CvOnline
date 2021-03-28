using Cv.Business.Interface;
using Cv.Models;
using Cv.Repository.Interface;
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

        public async Task<List<StateModel>> GetAllByCountryId(int id) => 
            await statesRepository.GetAllByCountryId(id);

        public async Task<StateModel> GetByIdStateId(int id) => 
            await statesRepository.GetByIdStateId(id);
    }
}