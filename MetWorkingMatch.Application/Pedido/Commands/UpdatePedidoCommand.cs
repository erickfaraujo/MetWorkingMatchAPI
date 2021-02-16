using MediatR;
using MetWorkingMatch.Application.Contracts;

namespace MetWorkingMatch.Application.Pedido.Commands
{
    public class UpdatePedidoCommand : IRequest<PedidoResponse>
    {
        public UpdatePedidoRequest UpdateRequest { get; }

        public UpdatePedidoCommand(UpdatePedidoRequest updateRequest, int action)
        {
            this.UpdateRequest = updateRequest;
            this.UpdateRequest.Action = action;
        }
    }
}
