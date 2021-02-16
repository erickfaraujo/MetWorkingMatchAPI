using MediatR;
using MetWorkingMatch.Application.Contracts;

namespace MetWorkingMatch.Application.Pedido.Commands
{
    public class CreatePedidoCommand : IRequest<PedidoResponse>
    {
        public CreatePedidoRequest PedidoRequest { get; }

        public CreatePedidoCommand(CreatePedidoRequest pedidoRequest)
        {
            PedidoRequest = pedidoRequest;
        }
    }
}
