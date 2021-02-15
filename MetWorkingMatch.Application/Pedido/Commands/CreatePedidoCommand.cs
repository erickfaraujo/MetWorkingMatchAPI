using MediatR;
using MetWorkingMatch.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
