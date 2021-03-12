using System.Threading.Tasks;
using Cv.API.Models;
using Cv.Business;
using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Cv.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientsBusiness clientsBusiness;
        public ClientController(IClientsBusiness clientsBusiness)
        {
            this.clientsBusiness = clientsBusiness;
        }

        [HttpPut]
        public async Task<ResultBus<bool>> Insert(ClientModel entity) => await clientsBusiness.Insert(entity);

        [HttpPost]
        public async Task<ResultBus<bool>> Replace(ClientModel entity) => await clientsBusiness.Replace(entity);

        [HttpDelete]
        [Route("{candidateId}")]
        public async Task<bool> Delete(string clientId) => await clientsBusiness.Delete(clientId);

        [HttpGet]
        [Route("count")]
        public async Task<long> Count(ClientSearch clientSearch) => 
            await clientsBusiness.Count(
                clientSearch.companyId, 
                clientSearch.name,
                clientSearch.countryId,
                clientSearch.stateId);

        [HttpGet]
        [Route("list")]
        public async Task<PagedListModel<ClientModel>> Get(ClientSearch clientSearch) =>
            await clientsBusiness.GetBy(
                clientSearch.companyId,
                clientSearch.page,
                clientSearch.pageSize,
                clientSearch.name,
                clientSearch.countryId,
                clientSearch.stateId);

        [HttpGet]
        [Route("{clientId}")]
        public async Task<ClientModel> GetBy(string clientId) =>
            await clientsBusiness.GetBy(clientId);

        [HttpGet]
        [Route("{companyId}/{code}")]
        public async Task<ClientModel> GetBy(string companyId, string code) =>
            await clientsBusiness.GetBy(companyId, code);
    }
}