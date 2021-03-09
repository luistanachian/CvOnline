using System.Linq;
using System.Threading.Tasks;
using Cv.API.Models;
using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Cv.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidatesBusiness candidatesBusiness;
        public CandidatesController(ICandidatesBusiness candidatesBusiness)
        {
            this.candidatesBusiness = candidatesBusiness;
        }

        [HttpGet]
        [Route("count")]
        public async Task<long> Count(CandidateSearch candidateSearch)
        {
            return await candidatesBusiness.Count(
                candidateSearch.companyId, 
                candidateSearch.name, 
                candidateSearch.skills?.ToList(), 
                candidateSearch.countryId, 
                candidateSearch.stateId,
                candidateSearch.status);
        }

        [HttpGet]
        [Route("list")]
        public async Task<PagedListModel<CandidateModel>> Get(CandidateSearch candidateSearch)
        {
            return await candidatesBusiness.GetBy(
                candidateSearch.companyId,
                candidateSearch.page,
                candidateSearch.pageSize,
                candidateSearch.name,
                candidateSearch.skills?.ToList(),
                candidateSearch.countryId,
                candidateSearch.stateId,
                candidateSearch.status);
        }

        [HttpGet]
        [Route("{companyId}/{candidateId}")]
        public async Task<CandidateModel> GetOne(string companyId, string candidateId)
        {
            return await candidatesBusiness.GetBy(companyId, candidateId);
        }


        [HttpPut]
        public async Task<bool> Insert(CandidateModel candidate)
        {
            return await candidatesBusiness.Insert(candidate);
        }
        [HttpPost]
        public async Task<bool> Replace(string userId, CandidateModel candidate)
        {
            return await candidatesBusiness.Replace(candidate, userId);
        }

        [HttpDelete]
        [Route("{candidateId}")]
        public async Task<bool> Delete(string candidateId)
        {
            return await candidatesBusiness.Delete(candidateId);
        }
    }
}