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
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesBusiness countriesBusiness;
        public CountriesController(ICountriesBusiness countriesBusiness)
        {
            this.countriesBusiness = countriesBusiness;
        }

        [HttpGet]
        public async Task<List<ComboResponse>> Get() =>
            (await countriesBusiness.GetAll()).Select(x => new ComboResponse { id = x.id, value = x.name }).ToList();


        [HttpGet("{id}")]
        public async Task<CountryModel> Get(int id) => await countriesBusiness.GetById(id);
    }
}
