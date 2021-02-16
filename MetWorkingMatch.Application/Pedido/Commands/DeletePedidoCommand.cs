using MediatR;
using MetWorkingMatch.Application.Contracts;

namespace MetWorkingMatch.Application.Pedido.Commands
{
    public class DeletePedidoCommand : IRequest<PedidoResponse>
    {
        public DeletePedidoRequest DeleteRequest { get; }

        public DeletePedidoCommand(DeletePedidoRequest deleteRequest)
        {
            this.DeleteRequest = deleteRequest;
        }
    }
}
