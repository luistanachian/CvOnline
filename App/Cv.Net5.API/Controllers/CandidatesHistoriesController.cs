using Cv.Business.Interface;
using Cv.Models;
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
    public class CandidatesHistoriesController : ControllerBase
    {
        private readonly ICandidatesHistoriesBusiness candidatesHistoriesBusiness;
        public CandidatesHistoriesController(ICandidatesHistoriesBusiness candidatesHistoriesBusiness)
        {
            this.candidatesHistoriesBusiness = candidatesHistoriesBusiness;
        }

        [HttpGet("{candidateId}")]
        public async Task<CandidateHistoryModel> Get(string candidateId) =>
            await candidatesHistoriesBusiness.GetBy(candidateId);
    }
}
