using System.Collections.Generic;
using System.Threading.Tasks;
using Cv.Business.Interface;
using Cv.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<CountryModel>> Get() => await countriesBusiness.GetAll();


        [Route("{id}")]
        [HttpGet]
        public async Task<CountryModel> Get(int id) => await countriesBusiness.GetById(id);
    }
}