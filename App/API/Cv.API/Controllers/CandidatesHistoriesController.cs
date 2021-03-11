using System.Threading.Tasks;
using Cv.Business.Interface;
using Cv.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cv.API.Controllers
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


        [HttpGet]
        [Route("{candidateId}")]
        public async Task<CandidateHistoryModel> Get(string candidateId) =>
            await candidatesHistoriesBusiness.GetBy(candidateId);

    }
}