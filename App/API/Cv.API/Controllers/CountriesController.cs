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
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountriesBusiness countriesBusiness;
        public CountriesController(ICountriesBusiness countriesBusiness)
        {
            this.countriesBusiness = countriesBusiness;
        }

        [HttpGet]
        public async Task<List<ComboResponse>> Get() =>
            (await countriesBusiness.GetAll()).Select(x => new ComboResponse {  id =  x.id, value = x.name }).ToList();

        [Route("{id}")]
        [HttpGet]
        public async Task<JsonResult> Get(int id) =>
            Json(JsonConvert.SerializeObject(await countriesBusiness.GetById(id)));
    }
}