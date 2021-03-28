using Cv.Business.Interface;
using Cv.Commons;
using Cv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cv.Net5.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidatesBusiness candidatesBusiness;
        public CandidatesController(ICandidatesBusiness candidatesBusiness)
        {
            this.candidatesBusiness = candidatesBusiness;
        }

        [HttpGet("count")]
        public async Task<long> Count([FromBody] CandidateSearch candidateSearch) =>
            await candidatesBusiness.Count(candidateSearch);

        [HttpGet("list")]
        public async Task<PagedListModel<CandidateModel>> Get([FromBody] CandidateSearch candidateSearch) =>
            await candidatesBusiness.GetBy(candidateSearch);

        [HttpGet("{companyId}/{candidateId}")]
        public async Task<ActionResult<CandidateModel>> GetOne([FromRoute] string companyId, [FromRoute] string candidateId)
        {
            if (!Validate.Guids(companyId, candidateId))
                return BadRequest();

            return await candidatesBusiness.GetBy(companyId, candidateId);
        }
        [HttpPost("{userId}")]
        public async Task<IActionResult> Save([FromRoute] string userId, [FromBody] CandidateModel candidate)
        {
            var (Valido, Errores) = BaseValidateFluent<CandidateModel>.ValidateRules(new CandidateValidations(), candidate);
            Dictionary<string, List<string>> errores = Valido ? new() : Errores;

            if (!Validate.Guids(userId))
                errores.Add("userId", new List<string> { "Debe ser un GUID valido" });

            return errores.Count > 0 ?
                BadRequest(JsonSerializer.Serialize(errores)) :
                StatusCode((int)await candidatesBusiness.Save(userId, candidate));
        }

        [HttpDelete("{companyId}/{candidateId}")]
        public async Task<IActionResult> Delete([FromRoute] string companyId, [FromRoute] string candidateId)
        {
            if (!Validate.Guids(candidateId, candidateId))
                return BadRequest();

            return StatusCode((int)await candidatesBusiness.Delete(companyId, candidateId));
        }
    }
}