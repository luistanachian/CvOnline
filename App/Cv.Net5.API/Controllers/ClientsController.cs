using Cv.Business;
using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Net5.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cv.Net5.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsBusiness clientsBusiness;
        public ClientsController(IClientsBusiness clientsBusiness)
        {
            this.clientsBusiness = clientsBusiness;
        }

        [HttpPut]
        public async Task<ResultBus> Insert(ClientModel entity) => await clientsBusiness.Insert(entity);

        [HttpPost]
        public async Task<ResultBus> Replace(ClientModel entity) => await clientsBusiness.Replace(entity);

        [HttpDelete("{clientId}")]
        public async Task<ResultBus> Delete(string clientId) => await clientsBusiness.Delete(clientId);

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

        [HttpGet("{clientId}")]
        public async Task<ClientModel> GetBy(string clientId) =>
            await clientsBusiness.GetBy(clientId);

        [HttpGet("{companyId}/{code}")]
        public async Task<ClientModel> GetBy(string companyId, string code) =>
            await clientsBusiness.GetBy(companyId, code);
    }
}
