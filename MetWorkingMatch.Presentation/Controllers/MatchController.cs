using MetWorkingMatch.Application.Conexao.Commands;
using MetWorkingMatch.Application.Conexao.Queries;
using MetWorkingMatch.Application.Contracts.Match;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MetWorkingMatch.Presentation.Controllers
{
    [Route("api/v1/[Controller]")]
    public class MatchController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllMatches(Guid id)
        {
            var query = new GetAllMatchesQuery(id);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("isMatch/{id}/{idAmigo}")]
        public async Task<IActionResult> IsMatch(Guid id, Guid idAmigo)
        {
            var query = new IsMatchQuery(id, idAmigo);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (Application.Contracts.Match.DeleteMatchRequest deleteMatchRequest)
        {
            var command = new DeleteMatchCommand(deleteMatchRequest);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
