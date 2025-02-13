﻿using Cv.Business.Interface;
using Cv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Cv.Net5.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsBusiness clientsBusiness;
        public ClientsController(IClientsBusiness clientsBusiness)
        {
            this.clientsBusiness = clientsBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ClientModel entity)
        {
            var result = await clientsBusiness.Save(entity);
            if (result == HttpStatusCode.BadRequest)
                return BadRequest("El codigo esta usado.");

            return StatusCode((int)result);
        }

        [HttpDelete("{companyId}/{clientId}")]
        public async Task<IActionResult> Delete(string companyId, string clientId)
        {
            return StatusCode((int)await clientsBusiness.Delete(companyId, clientId));
        }

        [HttpGet("count")]
        public async Task<long> Count(ClientSearch clientSearch) =>
            await clientsBusiness.Count(
                clientSearch.companyId,
                clientSearch.name,
                clientSearch.countryId,
                clientSearch.stateId);

        [HttpGet("list")]
        public async Task<PagedListModel<ClientModel>> Get(ClientSearch clientSearch) =>
            await clientsBusiness.GetBy(
                clientSearch.companyId,
                clientSearch.page,
                clientSearch.pageSize,
                clientSearch.name,
                clientSearch.countryId,
                clientSearch.stateId);

        [HttpGet("{companyId}/{clientId}")]
        public async Task<ClientModel> GetBy(string companyId, string clientId) =>
            await clientsBusiness.GetBy(companyId, clientId);
    }
}
