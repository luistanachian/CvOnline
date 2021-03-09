using System.Collections.Generic;
using System.Threading.Tasks;
using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<ComboResponse>> GetList(int countryId) => await statesBusiness.GetAllByCountryId(countryId);


        [HttpGet]
        [Route("state/{id}")]
        public async Task<StateModel> GetOne(int id) => await statesBusiness.GetByIdStateId(id);
    }
}