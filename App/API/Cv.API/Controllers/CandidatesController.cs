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
        public async Task<CandidateModel> GetOne(string companyId, string candidateId)
        {
            return await candidatesBusiness.GetBy(companyId, candidateId);
        }
    }
}