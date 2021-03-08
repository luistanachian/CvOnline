using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cv.Business.Interface;
using Cv.Models;
using Cv.Models.Enums;
using Microsoft.AspNetCore.Http;
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

        [Route("{companyId}")]
        [Route("{companyId}/{name}")]
        [Route("{companyId}/{name}/{countryId}")]
        [Route("{companyId}/{name}/{countryId}/{stateId}")]
        [Route("{companyId}/{name}/{countryId}/{stateId}/{status}")]
        [HttpGet]
        public async Task<long> Count(string companyId, string name = "", int countryId = 0, int stateId = 0, int? status = null)
        {
            StatusCandiateEnum? statusCandiateEnum = null; 
            if(status != null)
                statusCandiateEnum = (StatusCandiateEnum)status;

            return await candidatesBusiness.Count(companyId, name, countryId, stateId, statusCandiateEnum);
        }

    }
}
