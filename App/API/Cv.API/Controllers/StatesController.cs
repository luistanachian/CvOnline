using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cv.API.Models;
using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cv.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class StatesController : Controller
    {
        private readonly IStatesBusiness statesBusiness;
        public StatesController(IStatesBusiness statesBusiness)
        {
            this.statesBusiness = statesBusiness;
        }

        [HttpGet]
        [Route("states/{countryId}")]
        public async Task<List<ComboResponse>> GetList(int countryId) =>
            (await statesBusiness.GetAllByCountryId(countryId))
            .Select(x => new ComboResponse { id = x.id, value = x.name }).ToList();

        [HttpGet]
        [Route("state/{id}")]
        public async Task<StateModel> GetOne(int id) => await statesBusiness.GetByIdStateId(id);
    }
}