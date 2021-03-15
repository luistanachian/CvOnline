using Cv.Business;
using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Net5.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv.Net5.API.Controllers
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

        [HttpGet("count")]
        public async Task<long> Count(CandidateSearch candidateSearch) => 
            await candidatesBusiness.Count(
                candidateSearch.companyId,
                candidateSearch.name,
                candidateSearch.skills?.ToList(),
                candidateSearch.countryId,
                candidateSearch.stateId,
                candidateSearch.status);

        [HttpGet("list")]
        public async Task<PagedListModel<CandidateModel>> Get(CandidateSearch candidateSearch) =>
            await candidatesBusiness.GetBy(
                candidateSearch.companyId,
                candidateSearch.page,
                candidateSearch.pageSize,
                candidateSearch.name,
                candidateSearch.skills?.ToList(),
                candidateSearch.countryId,
                candidateSearch.stateId,
                candidateSearch.status);

        [HttpGet("{companyId}/{candidateId}")]
        public async Task<CandidateModel> GetOne(string companyId, string candidateId) =>
            await candidatesBusiness.GetBy(companyId, candidateId);

        [HttpPut]
        public async Task<ResultBus> Insert(CandidateModel candidate) =>
            await candidatesBusiness.Insert(candidate);

        [HttpPost]
        public async Task<ResultBus> Replace(string userId, CandidateModel candidate) =>
            await candidatesBusiness.Replace(candidate, userId); 

        [HttpDelete("{candidateId}")]
        public async Task<ResultBus> Delete(string candidateId) =>
            await candidatesBusiness.Delete(candidateId);
    }
}