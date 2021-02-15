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
            var query = ""; // colocar a chamada do GetMatchByUserIdQuery
            var result = ""; // colocar a chamada para o Mediator.Send(query)

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create ([FromBody] Guid idUser, Guid idAmigo) // TODO: Mudar o obj de entrada para um contrato
        {
            var command = ""; // TODO: colocar a chamada do CreateMatchCommand
            var result = ""; // TODO: colocar a chamada para o Mediator.Send(command)

            return Created("", result);
        }

        //[HttpDelete("{idUser}")]
        //public async Task<IActionResult> Delete (Guid idUser, [FromBody] Guid idAmigo)
        //{
        //    var command = ""; // TODO: colocar a chamada do DeleteMatchCommand
        //    var result = ""; // TODO: colocar a chamada para o Mediator.Send(command)

        //    return Ok(result);
        //}

    }
}
