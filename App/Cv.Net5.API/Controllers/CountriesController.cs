using Cv.Business.Interface;
using Cv.Models;
using Cv.Net5.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: <CountriesController>
        [HttpGet]
        public async Task<List<ComboResponse>> Get() =>
            (await countriesBusiness.GetAll()).Select(x => new ComboResponse { id = x.id, value = x.name }).ToList();


        // GET <CountriesController>/5
        [HttpGet("{id}")]
        public async Task<CountryModel> Get(int id) => await countriesBusiness.GetById(id);
    }
}
