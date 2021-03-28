using Cv.Business.Interface;
using Cv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Net5.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class StatesController : ControllerBase
    {
        private readonly IStatesBusiness statesBusiness;
        public StatesController(IStatesBusiness statesBusiness)
        {
            this.statesBusiness = statesBusiness;
        }

        [HttpGet("{countryId}")]
        public async Task<List<ComboResponse>> GetList([FromRoute] int countryId)
        {
            var states = await statesBusiness.GetAllByCountryId(countryId);
            if (states == null)
                return null;

            return states.Select(x => new ComboResponse { id = x.id, value = x.name }).ToList();
        }
        [HttpGet("id/{id}")]
        public async Task<StateModel> GetOne([FromRoute] int id) => await statesBusiness.GetByIdStateId(id);
    }
}
