using Cv.Business.Interface;
using Cv.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Net5.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesBusiness countriesBusiness;
        public CountriesController(ICountriesBusiness countriesBusiness)
        {
            this.countriesBusiness = countriesBusiness;
        }

        [HttpGet]
        public async Task<List<ComboResponse>> Get()
        {
            throw new Exception("hola soy un error");

            var countries = await countriesBusiness.GetAll();
            if (countries == null)
                return null;

            return countries.Select(x => new ComboResponse { id = x.id, value = x.name }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<CountryModel> Get([FromRoute] int id) => await countriesBusiness.GetById(id);
    }
}
