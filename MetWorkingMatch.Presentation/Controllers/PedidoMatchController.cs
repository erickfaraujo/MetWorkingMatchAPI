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
        public async Task<IActionResult> CreatePedido([FromBody] CreatePedidoRequest pedidoRequest)
        {
            var command = new CreatePedidoCommand(pedidoRequest);
            var result = await Mediator.Send(command);
            
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePedido(string pedido, int action)
        {
            var command = "";
            var result = "";

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePedido()
        {
            var command = "";
            var result = "";

            return Ok(result);
        }
    }
}
