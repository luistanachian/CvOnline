using Cv.Business.Interface;
using Cv.Models;
using Cv.Net5.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Net5.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStatesBusiness statesBusiness;
        public StatesController(IStatesBusiness statesBusiness)
        {
            this.statesBusiness = statesBusiness;
        }

        [HttpGet("states/{countryId}")]
        public async Task<List<ComboResponse>> GetList(int countryId) =>
            (await statesBusiness.GetAllByCountryId(countryId))
            .Select(x => new ComboResponse { id = x.id, value = x.name }).ToList();

        [HttpGet("state/{id}")]
        public async Task<StateModel> GetOne(int id) => await statesBusiness.GetByIdStateId(id);
    }
}
