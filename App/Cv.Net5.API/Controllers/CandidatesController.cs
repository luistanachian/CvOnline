﻿using Cv.Business;
using Cv.Business.Interface;
using Cv.Commons;
using Cv.Models;
using Cv.Models.Helpers;
using Cv.Net5.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
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
        public async Task<long> Count([FromBody] CandidateSearch candidateSearch) =>
            await candidatesBusiness.Count(
                candidateSearch.companyId,
                candidateSearch.name,
                candidateSearch.skills?.ToList(),
                candidateSearch.countryId,
                candidateSearch.stateId,
                candidateSearch.status);

        [HttpGet("list")]
        public async Task<PagedListModel<CandidateModel>> Get([FromBody] CandidateSearch candidateSearch) =>
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
        public async Task<ActionResult<CandidateModel>> GetOne([FromRoute] string companyId, [FromRoute] string candidateId)
        {
            if (!Validate.Guids(companyId, candidateId))
                return BadRequest();

            return await candidatesBusiness.GetBy(companyId, candidateId);
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> Insert([FromRoute] string userId, [FromBody] CandidateModel candidate)
        {
            if (!Validate.Guids(userId))
                return BadRequest();

            if (await candidatesBusiness.Insert(userId, candidate))
                return Ok();

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Replace([FromRoute] string userId, [FromBody] CandidateModel candidate)
        {
            if (!Validate.Guids(userId))
                return BadRequest();

            if (await candidatesBusiness.Replace(userId, candidate))
                return Ok();

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpDelete("{candidateId}")]
        public async Task<IActionResult> Delete([FromRoute] string companyId, [FromRoute] string candidateId)
        {
            if (!Validate.Guids(candidateId, candidateId))
                return BadRequest();

            if(await candidatesBusiness.Delete(companyId, candidateId))
                return Ok();

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}