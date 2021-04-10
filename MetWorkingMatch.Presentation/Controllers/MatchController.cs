using MetWorkingMatch.Application.Conexao.Commands;
using MetWorkingMatch.Application.Conexao.Queries;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Contracts.Match;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            return await ResponseBase(result);
        }

        [HttpGet("isMatch/{id}/{idAmigo}")]
        public async Task<IActionResult> IsMatch(Guid id, Guid idAmigo)
        {
            var query = new IsMatchQuery(id, idAmigo);
            var result = await Mediator.Send(query);

            return await ResponseBase(result);
        }

        [HttpPost("showTimeline/{id}")]
        public async Task<IActionResult> ShowTimeline(Guid id, [FromBody] Collection<Guid> idAmigo)
        {
            List<ShowTimelineResponse> showTimelineResponse = new();
            var response = new BaseResponse<List<ShowTimelineResponse>>();

            foreach (var a in idAmigo)
            {
                var query = new ShowTimelineQuery(id, a);
                var result = await Mediator.Send(query);
                Guid guid = new("00000000-0000-0000-0000-000000000000");

                if (!result.Data.IdAmigo.Equals(guid))
                {
                    showTimelineResponse.Add(result.Data);
                }
            }

            response.SetIsOk(showTimelineResponse);

            return await ResponseBase(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Application.Contracts.Match.DeleteMatchRequest deleteMatchRequest)
        {
            var command = new DeleteMatchCommand(deleteMatchRequest);
            var result = await Mediator.Send(command);

            return await ResponseBase(result);
        }
    }
}
