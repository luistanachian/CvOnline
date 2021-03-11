using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetList(int countryId) =>
            Json(JsonConvert.SerializeObject(
                (await statesBusiness.GetAllByCountryId(countryId)).Select(x => new { x.id, x.name }).ToList()));

        [HttpGet]
        [Route("state/{id}")]
        public async Task<IActionResult> GetOne(int id) => 
            Json(JsonConvert.SerializeObject(await statesBusiness.GetByIdStateId(id)));
    }
}