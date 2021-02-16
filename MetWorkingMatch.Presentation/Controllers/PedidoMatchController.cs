using Microsoft.AspNetCore.Mvc;
using MetWorkingMatch.Application.Pedido.Queries;
using System;
using System.Threading.Tasks;
using MetWorkingMatch.Application.Pedido.Commands;
using MetWorkingMatch.Application.Contracts;

namespace MetWorkingMatch.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    public class PedidoMatchController : BaseController
    {

        [HttpGet("enviados/{id}")]
        public async Task<IActionResult> GetPedidosEnviados(Guid id)
        {
            var query = new GetPedidosEnviadosByIdQuery(id);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("recebidos/{id}")]
        public async Task<IActionResult> GetPedidosRecebidos(Guid id)
        {
            var query = new GetPedidosRecebidosByIdQuery(id);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePedido([FromBody] CreatePedidoRequest createPedido)
        {
            var command = new CreatePedidoCommand(createPedido);
            var result = await Mediator.Send(command);
            
            return Ok();
        }

        [HttpPut("/aceitar")]
        public async Task<IActionResult> AceitaPedido(UpdatePedidoRequest updatePedido)
        {
            var command = new UpdatePedidoCommand(updatePedido, 2);
            var result = await Mediator.Send(command);

            return Ok();
        }

        [HttpPut("/rejeitar")]
        public async Task<IActionResult> RejeitaPedido(UpdatePedidoRequest updatePedido)
        {
            var command = new UpdatePedidoCommand(updatePedido, 3);
            var result = await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePedido(DeletePedidoRequest deletePedido)
        {
            var command = new DeletePedidoCommand(deletePedido);
            var result = Mediator.Send(command);

            return Ok();
        }
    }
}
