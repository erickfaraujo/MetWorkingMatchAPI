using MediatR;
using MetWorkingMatch.Application.Contracts;
using System;

namespace MetWorkingMatch.Application.Pedido.Queries
{
    public class GetPedidosRecebidosByIdQuery : IRequest<BaseResponse<PedidosMatchResponse>>
    {
        public Guid UserId { get; }

        public GetPedidosRecebidosByIdQuery(Guid UserId)
        {
            this.UserId = UserId;
        }

    }
}
